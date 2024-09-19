using PortifolioCore.Entities.DTOs.AboutDTOs;
using PortifolioCore.Entities.Models.AboutModels;

namespace PortifolioCore.Interfaces
{
    public interface IAboutServices
    {
        List<SkillModel> getSkills();
        InformationModel getInfo();
        ExperieceDTO getExperiences();
    }
}
