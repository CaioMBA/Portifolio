using PortifolioCore.Entities.Models.PortfolioModels;

namespace PortifolioCore.Interfaces
{
    public interface IPortfolioService
    {
        List<ProjectModel> getProjects();
    }
}
