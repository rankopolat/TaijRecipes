using System.Text.Json.Serialization;
using Postgrest.Attributes;
using Postgrest.Models;

namespace RecipeWebsite.Models;

[Table("recipes")]
public class Recipe : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("ingredients")]
    [JsonPropertyName("ingredients")]
    public List<Ingredient> Ingredients { get; set; } = new();

    [Column("steps")]
    [JsonPropertyName("steps")]
    public List<RecipeStep> Steps { get; set; } = new();

    [Column("image_path")]
    public string? ImagePath { get; set; }

    [Column("prep_time_minutes")]
    public int? PrepTimeMinutes { get; set; }

    [Column("cook_time_minutes")]
    public int? CookTimeMinutes { get; set; }

    [Column("servings")]
    public int? Servings { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [Column("user_id")]
    public string? UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    // Joined fields (not columns)
    [JsonIgnore]
    public string? CategoryName { get; set; }

    [JsonIgnore]
    public string? AuthorDisplayName { get; set; }

    [JsonIgnore]
    public string? ImageUrl { get; set; }
}

public class Ingredient
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;

    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;
}

public class RecipeStep
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("instruction")]
    public string Instruction { get; set; } = string.Empty;
}
