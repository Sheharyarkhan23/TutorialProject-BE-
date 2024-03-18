using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Models;

namespace TutorialProject.Controllers
{
    public class HeaderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<InfoAboutScreen>> GetInformationAboutScreen(int id)
        {
            var data = await _context.InfoAboutScreen.Where(a => a.Id == id).SingleOrDefaultAsync();

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

    }
}
