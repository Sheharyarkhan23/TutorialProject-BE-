using Microsoft.AspNetCore.Mvc;
using TutorialProject.Models;

namespace TutorialProject.Interfaces
{
    public interface IBlogRepository
    {
        Task<ActionResult<List<Blog>>> GetAllBlogAsync();
    }
}
