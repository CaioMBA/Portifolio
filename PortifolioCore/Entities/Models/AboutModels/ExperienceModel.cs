namespace PortifolioCore.Entities.Models.AboutModels
{
    public class ExperienceModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public required string Type { get; set; }
    }
}
