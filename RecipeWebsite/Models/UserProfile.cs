using Postgrest.Attributes;
using Postgrest.Models;

namespace RecipeWebsite.Models;

[Table("profiles")]
public class UserProfile : BaseModel
{
    [PrimaryKey("id")]
    public string Id { get; set; } = string.Empty;

    [Column("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [Column("avatar_url")]
    public string? AvatarUrl { get; set; }
}
