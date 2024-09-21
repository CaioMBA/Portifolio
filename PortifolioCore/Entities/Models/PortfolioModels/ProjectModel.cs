namespace PortifolioCore.Entities.Models.PortfolioModels
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
        public string? Description { get; set; }
    }
}
