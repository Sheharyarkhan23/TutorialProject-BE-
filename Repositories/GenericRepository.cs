using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;
using TutorialProject.Data;
using TutorialProject.Interfaces;
using TutorialProject.Models;

namespace TutorialProject.Repositories
{
    public class GenericRepository : Controller , IProfileRepository , IBlogRepository , IContactUsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public GenericRepository(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            this._context = context;
            _memoryCache = memoryCache;
        }

        public async Task<ActionResult<ProjectInformation>> GetInformationAboutProjectAsync(int id)
        {
            var data = await _context.ProjectInformation.Where(a => a.Id == id).SingleOrDefaultAsync();

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var cacheKey = "ProjectsList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Projects> ProjectsList))
            {
                ProjectsList = await _context.Projects.ToListAsync();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(500),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(200)
                };
                _memoryCache.Set(cacheKey, ProjectsList, cacheExpiryOptions);
            }
            return Ok(ProjectsList);
        }
        public async Task<ActionResult<List<Blog>>> GetAllBlogAsync()
        {
            
            var cacheKey = "BlogsList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Blog> BlogsList))
            {
                BlogsList = await _context.Blog.ToListAsync();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(500),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(200)
                };
                _memoryCache.Set(cacheKey, BlogsList, cacheExpiryOptions);
            }
            return BlogsList;
        }
        public async void SaveContactUsInformation(ContactUs contactus)
        {
            ContactUs contactUs = new ContactUs
            {
                FirstName = contactus.FirstName,
                LastName = contactus.LastName,
                Email = contactus.Email,
                Note = contactus.Note,
            };
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual  void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
