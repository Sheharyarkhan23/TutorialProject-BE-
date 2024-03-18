using TutorialProject.Models;

namespace TutorialProject.Interfaces
{
    public interface IContactUsRepository
    {
        void SaveContactUsInformation(ContactUs contactus);
    }
}
