using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RecipeWebsite.Models;
using Supabase.Gotrue;
using System.Security.Claims;

namespace RecipeWebsite.Services;

public class AuthService : AuthenticationStateProvider
{
    private readonly SupabaseService _supabase;
    private readonly ILocalStorageService _localStorage;
    private Session? _currentSession;

    public AuthService(SupabaseService supabase, ILocalStorageService localStorage)
    {
        _supabase = supabase;
        _localStorage = localStorage;
    }

    public string? CurrentUserId => _currentSession?.User?.Id;
    public bool IsAuthenticated => _currentSession?.User != null;

    public async Task InitializeAsync()
    {
        try
        {
            await _supabase.EnsureInitializedAsync();

            var accessToken = await _localStorage.GetItemAsStringAsync("sb-access-token");
            var refreshToken = await _localStorage.GetItemAsStringAsync("sb-refresh-token");

            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                var session = await _supabase.Client.Auth.SetSession(accessToken, refreshToken);
                _currentSession = session;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Auth restore failed: {ex.Message}");
            await ClearSession();
        }

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task<(bool Success, string? Error)> SignUpAsync(string email, string password, string displayName)
    {
        try
        {
            await _supabase.EnsureInitializedAsync();
            var session = await _supabase.Client.Auth.SignUp(email, password);
            if (session?.User != null)
            {
                _currentSession = session;
                await PersistSession(session);

                // Update profile display name
                try
                {
                    await _supabase.Client.From<UserProfile>()
                        .Where(p => p.Id == session.User.Id)
                        .Set(p => p.DisplayName, displayName)
                        .Update();
                }
                catch { /* Profile trigger may not have fired yet */ }

                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                return (true, null);
            }
            return (false, "Sign up failed. Please check your email for a confirmation link.");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<(bool Success, string? Error)> SignInAsync(string email, string password)
    {
        try
        {
            await _supabase.EnsureInitializedAsync();
            var session = await _supabase.Client.Auth.SignIn(email, password);
            if (session != null)
            {
                _currentSession = session;
                await PersistSession(session);
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                return (true, null);
            }
            return (false, "Invalid email or password.");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task SignOutAsync()
    {
        try
        {
            await _supabase.Client.Auth.SignOut();
        }
        catch { }

        _currentSession = null;
        await ClearSession();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal user;

        if (_currentSession?.User != null)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, _currentSession.User.Id ?? ""),
                new Claim(ClaimTypes.Email, _currentSession.User.Email ?? ""),
                new Claim(ClaimTypes.Name, _currentSession.User.Email ?? "")
            };
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "supabase"));
        }
        else
        {
            user = new ClaimsPrincipal(new ClaimsIdentity());
        }

        return Task.FromResult(new AuthenticationState(user));
    }

    private async Task PersistSession(Session session)
    {
        if (session.AccessToken != null)
            await _localStorage.SetItemAsStringAsync("sb-access-token", session.AccessToken);
        if (session.RefreshToken != null)
            await _localStorage.SetItemAsStringAsync("sb-refresh-token", session.RefreshToken);
    }

    private async Task ClearSession()
    {
        try
        {
            await _localStorage.RemoveItemAsync("sb-access-token");
            await _localStorage.RemoveItemAsync("sb-refresh-token");
        }
        catch { }
    }
}
