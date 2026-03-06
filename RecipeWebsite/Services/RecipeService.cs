using RecipeWebsite.Models;
using Supabase;

namespace RecipeWebsite.Services;

public class RecipeService
{
    private readonly SupabaseService _supabase;
    private readonly StorageService _storageService;
    private List<Category>? _categoriesCache;

    public RecipeService(SupabaseService supabase, StorageService storageService)
    {
        _supabase = supabase;
        _storageService = storageService;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        if (_categoriesCache != null) return _categoriesCache;

        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Category>()
            .Order("name", Postgrest.Constants.Ordering.Ascending)
            .Get();

        _categoriesCache = response.Models;
        return _categoriesCache;
    }

    public async Task<List<Recipe>> GetRecentRecipesAsync(int limit = 6)
    {
        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Recipe>()
            .Order("created_at", Postgrest.Constants.Ordering.Descending)
            .Limit(limit)
            .Get();

        var recipes = response.Models;
        await EnrichRecipesAsync(recipes);
        return recipes;
    }

    public async Task<List<Recipe>> SearchRecipesAsync(string? searchTerm = null, int? categoryId = null)
    {
        await _supabase.EnsureInitializedAsync();
        var table = _supabase.Client.From<Recipe>();

        Postgrest.Table<Recipe> query = categoryId.HasValue
            ? table.Where(r => r.CategoryId == categoryId.Value)
            : table.Filter("id", Postgrest.Constants.Operator.GreaterThan, "0");

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Filter("title", Postgrest.Constants.Operator.ILike, $"%{searchTerm}%");

        var response = await query
            .Order("created_at", Postgrest.Constants.Ordering.Descending)
            .Get();

        var recipes = response.Models;
        await EnrichRecipesAsync(recipes);
        return recipes;
    }

    public async Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Recipe>()
            .Where(r => r.Id == id)
            .Get();

        var recipe = response.Models.FirstOrDefault();
        if (recipe != null)
        {
            await EnrichRecipeAsync(recipe);
        }
        return recipe;
    }

    public async Task<List<Recipe>> GetMyRecipesAsync(string userId)
    {
        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Recipe>()
            .Where(r => r.UserId == userId)
            .Order("created_at", Postgrest.Constants.Ordering.Descending)
            .Get();

        var recipes = response.Models;
        await EnrichRecipesAsync(recipes);
        return recipes;
    }

    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Recipe>().Insert(recipe);
        var created = response.Models.First();
        await EnrichRecipeAsync(created);
        return created;
    }

    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        await _supabase.EnsureInitializedAsync();
        var response = await _supabase.Client.From<Recipe>()
            .Where(r => r.Id == recipe.Id)
            .Set(r => r.Title, recipe.Title)
            .Set(r => r.Description, recipe.Description)
            .Set(r => r.Ingredients, recipe.Ingredients)
            .Set(r => r.Steps, recipe.Steps)
            .Set(r => r.ImagePath, recipe.ImagePath)
            .Set(r => r.PrepTimeMinutes, recipe.PrepTimeMinutes)
            .Set(r => r.CookTimeMinutes, recipe.CookTimeMinutes)
            .Set(r => r.Servings, recipe.Servings)
            .Set(r => r.CategoryId, recipe.CategoryId)
            .Update();

        var updated = response.Models.First();
        await EnrichRecipeAsync(updated);
        return updated;
    }

    public async Task DeleteRecipeAsync(int id)
    {
        await _supabase.EnsureInitializedAsync();
        await _supabase.Client.From<Recipe>()
            .Where(r => r.Id == id)
            .Delete();
    }

    private async Task EnrichRecipesAsync(List<Recipe> recipes)
    {
        var categories = await GetCategoriesAsync();
        var userIds = recipes.Select(r => r.UserId).Where(id => id != null).Distinct().ToList();

        var profiles = new List<UserProfile>();
        if (userIds.Any())
        {
            var profileResponse = await _supabase.Client.From<UserProfile>()
                .Filter("id", Postgrest.Constants.Operator.In, userIds)
                .Get();
            profiles = profileResponse.Models;
        }

        foreach (var recipe in recipes)
        {
            recipe.CategoryName = categories.FirstOrDefault(c => c.Id == recipe.CategoryId)?.Name;
            recipe.AuthorDisplayName = profiles.FirstOrDefault(p => p.Id == recipe.UserId)?.DisplayName ?? "Unknown";
            recipe.ImageUrl = _storageService.GetPublicUrl(recipe.ImagePath);
        }
    }

    private async Task EnrichRecipeAsync(Recipe recipe)
    {
        await EnrichRecipesAsync(new List<Recipe> { recipe });
    }
}
