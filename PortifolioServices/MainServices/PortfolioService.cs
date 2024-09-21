using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.PortfolioModels;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.DataBases.SqlServer;

namespace PortifolioServices.MainServices
{
    public class PortfolioService : IPortfolioService
    {
        private readonly PortfolioRepository _repository;
        private readonly Utils _utils;
        public PortfolioService(PortfolioRepository repository, Utils utils)
        {
            _repository = repository;
            _utils = utils;
        }

        public List<ProjectModel> getProjects()
        {
            var response = _repository.getProjects();

            if (response == null)
            {
                throw new Exception("No projects found");
            }

            return response;
        }
    }
}
