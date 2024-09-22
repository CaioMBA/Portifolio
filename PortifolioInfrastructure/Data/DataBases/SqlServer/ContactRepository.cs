using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.GeneralSettingsModels;

namespace PortifolioInfrastructure.Data.DataBases.SqlServer
{
    public class ContactRepository
    {
        private readonly DataBaseDefaultAccess _db;
        private readonly Utils _utils;
        private readonly DataBaseConnection _connection;
        public ContactRepository(DataBaseDefaultAccess db, Utils utils)
        {
            _db = db;
            _utils = utils;
            _connection = _utils.GetDataBase("Default");
        }
    }
}
