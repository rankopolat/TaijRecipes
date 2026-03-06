using Supabase;

namespace RecipeWebsite.Services;

public class SupabaseService
{
    public Client Client { get; }

    public SupabaseService(string url, string anonKey)
    {
        var options = new SupabaseOptions
        {
            AutoConnectRealtime = false
        };
        Client = new Client(url, anonKey, options);
    }

    public async Task InitializeAsync()
    {
        await Client.InitializeAsync();
    }
}
