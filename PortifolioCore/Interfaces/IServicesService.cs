using PortifolioCore.Entities.Models.ServicesModels;

namespace PortifolioCore.Interfaces
{
    public interface IServicesService
    {
        List<AvailableServiceModel> getServices();
    }
}
