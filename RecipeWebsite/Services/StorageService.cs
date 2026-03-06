using Supabase;

namespace RecipeWebsite.Services;

public class StorageService
{
    private readonly SupabaseService _supabase;
    private const string BucketName = "recipe-images";

    public StorageService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<string?> UploadImageAsync(Stream fileStream, string fileName)
    {
        try
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            var uniqueName = $"{Guid.NewGuid()}{extension}";

            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            await _supabase.Client.Storage
                .From(BucketName)
                .Upload(bytes, uniqueName);

            return uniqueName;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload error: {ex.Message}");
            return null;
        }
    }

    public async Task DeleteImageAsync(string? imagePath)
    {
        if (string.IsNullOrEmpty(imagePath)) return;

        try
        {
            await _supabase.Client.Storage
                .From(BucketName)
                .Remove(new List<string> { imagePath });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Delete image error: {ex.Message}");
        }
    }

    public string? GetPublicUrl(string? imagePath)
    {
        if (string.IsNullOrEmpty(imagePath)) return null;

        return _supabase.Client.Storage
            .From(BucketName)
            .GetPublicUrl(imagePath);
    }
}
