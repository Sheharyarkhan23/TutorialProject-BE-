using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Interfaces;
using TutorialProject.Models;

namespace TutorialProject.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(ApplicationDbContext context, IContactUsRepository contactusrepository)
        {
            _contactUsRepository = contactusrepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<Projects>>> SaveContactFromInformation(ContactUs contactus)
        {
            _contactUsRepository.SaveContactUsInformation(contactus);
            return Ok();
        }

    }
}
