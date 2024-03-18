using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Interfaces;
using TutorialProject.Models;
using TutorialProject.Repositories;

namespace TutorialProject.Controllers
{
    public class ProfileController : Controller 
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(ApplicationDbContext context,IProfileRepository Prepository)
        {
            _profileRepository = Prepository;
        }
        [HttpGet]
        public async Task<ActionResult<ProjectInformation>> GetInformationAboutProject(int id)
        {
            var data = await _profileRepository.GetInformationAboutProjectAsync(id);
            return data;
        }
        [HttpGet]
        public async Task<ActionResult<List<Projects>>> GetAllProjects()
        {
            var projects = await _profileRepository.GetAllProjectsAsync();
            return Ok(projects);
        }

    }
}
