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

        public String getSkills()
        {
            var response = _repository.getSkills();

            if (response == null)
            {
                throw new Exception("Error while trying to get skills");
            }

            StringBuilder skillTree = new StringBuilder();

            foreach (SkillModel skill in response)
            {
                skillTree.Append("<li class=\"skill-item\">");
                skillTree.Append($"<h5>{skill.Name}</h5>");
                skillTree.Append($"<div class=\"progressing\">");
                skillTree.Append($"<div class=\"progress-in\" style=\"width: {skill.Level}%;\"></div>");
                skillTree.Append($"<div class=\"skill-percent\">{skill.Level}</div>");
                skillTree.Append("</div>");
                skillTree.Append("</li>");
            }

            return skillTree.ToString();
        }
    }
}
