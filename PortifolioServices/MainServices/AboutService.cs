using Microsoft.VisualBasic;
using PortifolioCore.Entities.DTOs.AboutDTOs;
using PortifolioCore.Entities.Models.AboutModels;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.DataBases.SqlServer;
using System.Text;

namespace PortifolioServices.MainServices
{
    public class AboutService : IAboutServices
    {
        private readonly AboutRepository _repository;
        public AboutService(AboutRepository repository)
        {
            _repository = repository;
        }

        public List<SkillModel> getSkills()
        {
            List<SkillModel>? response = _repository.GetSkills();

            if (response == null)
            {
                throw new Exception("Error while trying to get skills");
            }
            return response;
        }

        public InformationModel getInfo()
        {
            InformationModel? response = _repository.GetInformation();
            if (response == null)
            {
                throw new Exception("Error while trying to get information");
            }
            return response;
        }

        public ExperieceDTO getExperiences()
        {
            List<ExperienceModel>? response = _repository.GetExperiences();
            if (response == null)
            {
                throw new Exception("Error while trying to get information");
            }

            List<ExperienceModel> EducationList = response.Where(x => x.Type.ToUpper() == "EDUCATION").ToList();
            List<ExperienceModel> JobList = response.Where(x => x.Type.ToUpper() == "JOB").ToList();



            return new ExperieceDTO()
            {
                Education = EducationList,
                Job = JobList
            };
        }
    }
}
