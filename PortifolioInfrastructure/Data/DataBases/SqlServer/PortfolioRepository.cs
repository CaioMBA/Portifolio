using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioCore.Entities.Models.PortfolioModels;

namespace PortifolioInfrastructure.Data.DataBases.SqlServer
{
    public class PortfolioRepository
    {
        private readonly DataBaseDefaultAccess _db;
        private readonly Utils _utils;
        private readonly DataBaseConnection _connection;
        public PortfolioRepository(DataBaseDefaultAccess db, Utils utils)
        {
            _db = db;
            _utils = utils;
            _connection = _utils.GetDataBase("Default");
        }

        public List<ProjectModel>? getProjects()
        {
            return _db.Query<ProjectModel>(
                sQuery: $"SELECT TOP 6 p.ProjectID, Name, Image, link, Description FROM Projects p ORDER BY p.ProjectID DESC;",
                parameter: null,
                connection: _connection).Result;
        }
    }
}
