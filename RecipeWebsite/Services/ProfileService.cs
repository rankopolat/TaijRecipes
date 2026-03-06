using RecipeWebsite.Models;

namespace RecipeWebsite.Services;

public class ProfileService
{
    private readonly SupabaseService _supabase;

    public ProfileService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<UserProfile?> GetProfileAsync(string userId)
    {
        var response = await _supabase.Client.From<UserProfile>()
            .Where(p => p.Id == userId)
            .Get();

        return response.Models.FirstOrDefault();
    }

    public async Task UpdateDisplayNameAsync(string userId, string displayName)
    {
        await _supabase.Client.From<UserProfile>()
            .Where(p => p.Id == userId)
            .Set(p => p.DisplayName, displayName)
            .Update();
    }
}
