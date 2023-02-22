using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CA.Models;
using CA.Db;
using CA.Entities;
namespace CA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogPostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Text>> Create(Text blogPost)
        {
            _context.Texts.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(blogPost.Title, new { id = blogPost.Id }, blogPost);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Text>> GetById(int id)
        {
            var blogPost = await _context.Texts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }
    }
}
