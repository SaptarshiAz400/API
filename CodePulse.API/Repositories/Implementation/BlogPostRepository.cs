using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation
{
    public class BlogPostRepository:IBlogPostRepository
    {
        //create
        //a constructor to inject the database context
        private readonly ApplicationDbContext _dbContext;
        public BlogPostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //write code for the add blog post method
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            //write code to add the blog post to the database
            _dbContext.BlogPosts.Add(blogPost);
            await _dbContext.SaveChangesAsync();
            return blogPost;


        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _dbContext.BlogPosts.ToListAsync();
        }
        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            return await _dbContext.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == id);
        }
        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            _dbContext.BlogPosts.Update(blogPost);
            await _dbContext.SaveChangesAsync();
            return blogPost;
        }
        //write code for the delete blog post method
        public async Task DeleteAsync(Guid id)
        {
            var blogPost = await GetByIdAsync(id);
            _dbContext.BlogPosts.Remove(blogPost);
            await _dbContext.SaveChangesAsync();
        }
    }
}
