using Microsoft.AspNetCore.Mvc;

namespace TutorialProject.Models
{
    public class ContactUsInformation : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
