using PortifolioCore.Auxiliary;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.DataBases.SqlServer;

namespace PortifolioServices.MainServices
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _repository;
        private readonly Utils _utils;
        public ContactService(ContactRepository repository, Utils utils)
        {
            _repository = repository;
            _utils = utils;
        }
    }
}
