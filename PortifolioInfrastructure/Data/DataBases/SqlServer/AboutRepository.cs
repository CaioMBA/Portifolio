using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.AboutModels;
using PortifolioCore.Entities.Models.GeneralSettingsModels;

namespace PortifolioInfrastructure.Data.DataBases.SqlServer
{
    public class AboutRepository
    {
        private readonly DataBaseDefaultAccess _db;
        private readonly Utils _utils;
        private readonly DataBaseConnection _connection;
        public AboutRepository(DataBaseDefaultAccess db, Utils utils)
        {
            _db = db;
            _utils = utils;
            _connection = _utils.GetDataBase("Default");
        }

        public List<SkillModel>? getSkills()
        {
            return _db.Query<SkillModel>(@"SELECT Name, Level FROM Skills ORDER BY Level DESC", null, _connection).Result;
        }
    }
}
