using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using RecipeWebsite.Helpers;

namespace RecipeWebsite.Services;

public class WoolworthsProduct
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public string PackageSize { get; set; } = "";
    public string? ImageUrl { get; set; }
    public string CupPrice { get; set; } = "";
    public bool IsFromApi { get; set; }
}

public class WoolworthsService
{
    private readonly HttpClient _httpClient;
    private const string CorsProxy = "https://corsproxy.io/?";
    private const string WoolworthsSearchUrl = "https://www.woolworths.com.au/apis/ui/Search/products";

    public WoolworthsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WoolworthsProduct>> SearchProductsAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
            return new List<WoolworthsProduct>();

        try
        {
            return await SearchLiveAsync(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Live search failed, using static data: {ex.Message}");
            return SearchStatic(query);
        }
    }

    private async Task<List<WoolworthsProduct>> SearchLiveAsync(string query)
    {
        var requestBody = new
        {
            SearchTerm = query,
            PageSize = 12,
            PageNumber = 1,
            SortType = "TraderRelevance",
            Location = $"{CorsProxy}{WoolworthsSearchUrl}"
        };

        var request = new HttpRequestMessage(HttpMethod.Post, $"{CorsProxy}{WoolworthsSearchUrl}");
        request.Content = JsonContent.Create(new
        {
            SearchTerm = query,
            PageSize = 12,
            PageNumber = 1,
            SortType = "TraderRelevance"
        });
        request.Headers.Add("Accept", "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();

        var products = new List<WoolworthsProduct>();

        if (json.TryGetProperty("Products", out var productsArray))
        {
            foreach (var productGroup in productsArray.EnumerateArray())
            {
                if (!productGroup.TryGetProperty("Products", out var innerProducts))
                    continue;

                foreach (var p in innerProducts.EnumerateArray())
                {
                    var product = new WoolworthsProduct { IsFromApi = true };

                    if (p.TryGetProperty("Name", out var name))
                        product.Name = name.GetString() ?? "";

                    if (p.TryGetProperty("Description", out var desc))
                        product.Description = desc.GetString() ?? "";

                    if (p.TryGetProperty("Price", out var price) && price.ValueKind == JsonValueKind.Number)
                        product.Price = price.GetDecimal();

                    if (p.TryGetProperty("PackageSize", out var size))
                        product.PackageSize = size.GetString() ?? "";

                    if (p.TryGetProperty("MediumImageFile", out var img))
                        product.ImageUrl = img.GetString();

                    if (p.TryGetProperty("CupPrice", out var cup))
                        product.CupPrice = cup.GetString() ?? "";

                    if (product.Price > 0)
                        products.Add(product);
                }
            }
        }

        if (products.Count == 0)
            return SearchStatic(query);

        return products;
    }

    private List<WoolworthsProduct> SearchStatic(string query)
    {
        return GroceryProducts.Search(query)
            .Take(12)
            .Select(p => new WoolworthsProduct
            {
                Name = p.Name,
                Description = p.Category,
                Price = p.Price,
                PackageSize = p.Size,
                IsFromApi = false
            })
            .ToList();
    }
}
