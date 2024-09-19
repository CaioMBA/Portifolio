using PortifolioCore.Entities.Models.AboutModels;

namespace PortifolioCore.Entities.DTOs.AboutDTOs
{
    public class ExperieceDTO
    {
        public required List<ExperienceModel> Education { get; set; }
        public required List<ExperienceModel> Job { get; set; }
    }
}
