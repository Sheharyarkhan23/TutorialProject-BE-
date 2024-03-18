using System.ComponentModel.DataAnnotations;

namespace TutorialProject.Models
{
    public class ContactUs
    {
        [Key]
        public Int32? Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? PhoneNo { get; set; }
        public String? Email { get; set; }
        public String? Note { get; set; }
    }
}
