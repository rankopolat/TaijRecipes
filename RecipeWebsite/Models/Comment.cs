using System.Text.Json.Serialization;
using Postgrest.Attributes;
using Postgrest.Models;

namespace RecipeWebsite.Models;

[Table("comments")]
public class Comment : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Column("user_id")]
    public string? UserId { get; set; }

    [Column("content")]
    public string Content { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public string? AuthorDisplayName { get; set; }
}
