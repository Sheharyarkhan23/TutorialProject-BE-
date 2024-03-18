using System.ComponentModel.DataAnnotations;

namespace TutorialProject.Models
{
    public class Blog
    {
        [Key]
        public int id { get; set; }
        public String? imglink { get; set; }
        public String? Heading { get; set; }
        public String? Description { get; set; }
        public String? Details { get; set; }
    }
}
