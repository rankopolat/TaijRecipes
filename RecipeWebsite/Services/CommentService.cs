using RecipeWebsite.Models;

namespace RecipeWebsite.Services;

public class CommentService
{
    private readonly SupabaseService _supabase;

    public CommentService(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Comment>> GetCommentsAsync(int recipeId)
    {
        var response = await _supabase.Client.From<Comment>()
            .Where(c => c.RecipeId == recipeId)
            .Order("created_at", Postgrest.Constants.Ordering.Ascending)
            .Get();

        var comments = response.Models;

        // Enrich with author names
        var userIds = comments.Select(c => c.UserId).Where(id => id != null).Distinct().ToList();
        if (userIds.Any())
        {
            var profileResponse = await _supabase.Client.From<UserProfile>()
                .Filter("id", Postgrest.Constants.Operator.In, userIds)
                .Get();
            var profiles = profileResponse.Models;

            foreach (var comment in comments)
            {
                comment.AuthorDisplayName = profiles.FirstOrDefault(p => p.Id == comment.UserId)?.DisplayName ?? "Unknown";
            }
        }

        return comments;
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        var response = await _supabase.Client.From<Comment>().Insert(comment);
        return response.Models.First();
    }

    public async Task DeleteCommentAsync(int id)
    {
        await _supabase.Client.From<Comment>()
            .Where(c => c.Id == id)
            .Delete();
    }
}
