using Microsoft.AspNetCore.Mvc;
using TutorialProject.Models;

namespace TutorialProject.Interfaces
{
    public interface IProfileRepository
    {
        Task<ActionResult<ProjectInformation>> GetInformationAboutProjectAsync(int id);
        Task<IActionResult> GetAllProjectsAsync();

    }
}
