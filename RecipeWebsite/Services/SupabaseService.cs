using Supabase;

namespace RecipeWebsite.Services;

public class SupabaseService
{
    public Client Client { get; }
    private bool _initialized;

    public SupabaseService(string url, string anonKey)
    {
        var options = new SupabaseOptions
        {
            AutoConnectRealtime = false,
            AutoRefreshToken = false
        };
        Client = new Client(url, anonKey, options);
    }

    public async Task EnsureInitializedAsync()
    {
        if (_initialized) return;

        try
        {
            await Client.InitializeAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Supabase init: {ex.Message}");
            // Even if InitializeAsync fails (e.g. WebSocket issues in WASM),
            // the REST-based clients (Postgrest, GoTrue, Storage) still work.
        }
        finally
        {
            _initialized = true;
        }
    }
}
