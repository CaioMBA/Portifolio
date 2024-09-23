using PortifolioCore.Entities.Models.ContactModels;

namespace PortifolioCore.Interfaces
{
    public interface IContactService
    {
        void SendMail(string toMailAddress, string name, string fromMailAddress, string subject, string message);
    }
}
