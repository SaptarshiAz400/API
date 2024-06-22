using CodePulse.API.Models.Domain;

namespace CodePulse.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        //write code for the add blog post interface method
        Task<BlogPost>CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost> GetByIdAsync(Guid id);
        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task DeleteAsync(Guid id);
    }
}
