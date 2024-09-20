using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioCore.Entities.Models.ServicesModels;

namespace PortifolioInfrastructure.Data.DataBases.SqlServer
{
    public class ServicesRepository
    {
        private readonly DataBaseDefaultAccess _db;
        private readonly Utils _utils;
        private readonly DataBaseConnection _connection;
        public ServicesRepository(DataBaseDefaultAccess db, Utils utils)
        {
            _db = db;
            _utils = utils;
            _connection = _utils.GetDataBase("Default");
        }

        public List<AvailableServiceModel>? getAvailableServices()
        {
            return _db.Query<AvailableServiceModel>($"SELECT Name, Icon, Description FROM AVAILABLESERVICES", null, _connection).Result;
        }
    }
}
