using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        //create a constator injection for the blog post repository
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        [HttpPost]
        //write code for the add blog post method
        public async Task<IActionResult> AddBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            //coverting the request DTO to a domain object
            var blogPost = new BlogPost
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                IsVisible = request.IsVisible
            };
            //
            //write code to add the blog post to the database
            blogPost = await _blogPostRepository.CreateAsync(blogPost);
            //write code domain model to DTO
            var response = new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible
            };


            return Ok(response);
        }
        //write a code for get all blog post met
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await _blogPostRepository.GetAllAsync();

            var blogPostDtos = blogPosts.Select(bp => new BlogPostDTO
            {
                Id = bp.Id,
                Title = bp.Title,
                ShortDescription = bp.ShortDescription,
                Content = bp.Content,
                FeaturedImageUrl = bp.FeaturedImageUrl,
                UrlHandle = bp.UrlHandle,
                PublishedDate = bp.PublishedDate,
                Author = bp.Author,
                IsVisible = bp.IsVisible
            }).ToList();

            return Ok(blogPostDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(Guid id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            var blogPostDto = new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible
            };

            return Ok(blogPostDto);
        }
        //write a code for update blog post
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(Guid id, [FromBody] UpdateBlogPostRequestDto request)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.Title = request.Title;
            blogPost.ShortDescription = request.ShortDescription;
            blogPost.Content = request.Content;
            blogPost.FeaturedImageUrl = request.FeaturedImageUrl;
            blogPost.UrlHandle = request.UrlHandle;
            blogPost.PublishedDate = request.PublishedDate;
            blogPost.Author = request.Author;
            blogPost.IsVisible = request.IsVisible;

            await _blogPostRepository.UpdateAsync(blogPost);



            return NoContent();
        }
        //write a code for delete blog post
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(Guid id)
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }
            else
            {
                await _blogPostRepository.DeleteAsync(id);
            }

            ;

            return NoContent();
        }
    }
}
