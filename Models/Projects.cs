using System.ComponentModel.DataAnnotations;

namespace TutorialProject.Models
{
    public class Projects
    {
        [Key]
        public Int32 Id { get; set; }
        public String? Description { get; set; }
    }
}
