using Postgrest.Attributes;
using Postgrest.Models;

namespace RecipeWebsite.Models;

[Table("categories")]
public class Category : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }
}
