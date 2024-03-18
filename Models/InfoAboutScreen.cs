using System.ComponentModel.DataAnnotations;

namespace TutorialProject.Models
{
    public class InfoAboutScreen
    {
        [Key]
        public Int32 Id { get; set; }
        public String? Heading { get; set; }
        public String? Information { get; set; }
    }
}
