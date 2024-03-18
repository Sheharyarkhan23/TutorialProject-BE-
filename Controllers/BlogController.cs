using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Interfaces;
using TutorialProject.Models;

namespace TutorialProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(ApplicationDbContext context,IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Projects>>> GetAllBlogs()
        {
            var data = await _blogRepository.GetAllBlogAsync();
            return Ok(data); 
        }

    }
}
