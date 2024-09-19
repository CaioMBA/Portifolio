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

        public List<SkillModel>? GetSkills()
        {
            return _db.Query<SkillModel>(@"SELECT Name, Level FROM Skills ORDER BY Level DESC", null, _connection).Result;
        }

        public InformationModel? GetInformation()
        {
            return _db.QueryFirstOrDefault<InformationModel>(@"SELECT 
                                                                FORMAT(Birthday, 'dd MMM yyyy') AS Birthday, 
                                                                (DATEDIFF(MONTH, Birthday, CAST(GETUTCDATE() AS DATE)) / 12) AS Age, 
                                                                Website, 
                                                                Email, 
                                                                Degree,
                                                                Phone, 
                                                                Location, 
                                                                IIF(Freelance = 1, 'Available', 'Not-Available') AS Freelance
                                                               FROM AboutInformations", null, _connection).Result;
        }

        public List<ExperienceModel>? GetExperiences()
        {
            return _db.Query<ExperienceModel>(@"SELECT Name, Description, Year(StartDate) StartDate, Year(ISNULL(EndDate, GETUTCDATE())) EndDate, Type FROM Experiences", null, _connection).Result;
        }
    }
}
