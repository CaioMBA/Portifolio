using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.ServicesModels;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.DataBases.SqlServer;

namespace PortifolioServices.MainServices
{
    public class ServicesService : IServicesService
    {
        private readonly ServicesRepository _repo;
        private Utils _utils;
        public ServicesService(ServicesRepository repo, Utils utils)
        {
            _repo = repo;
            _utils = utils;
        }

        public List<AvailableServiceModel> getServices()
        {
            List<AvailableServiceModel>? response = _repo.getAvailableServices();

            if (response == null)
            {
                throw new Exception("No Availabel Services found");
            }

            return response;
        }
    }
}
