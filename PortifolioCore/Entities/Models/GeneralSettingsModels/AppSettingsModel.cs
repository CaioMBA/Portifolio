namespace PortifolioCore.Entities.Models.GeneralSettingsModels
{
    public class AppSettingsModel
    {
        public string? AppName { get; set; }
        public double? AppVersion { get; set; }
        public List<DataBaseConnection>? DataBaseConnections { get; set; }
        public List<ApiConnection>? ApiConnections { get; set; }
    }

    public class DataBaseConnection
    {
        public required string DataBaseID { get; set; }
        public required string Type { get; set; }
        public required string ConnectionString { get; set; }
        public string? Name { get; set; }
        public string? Collection { get; set; }
    }
    public class ApiConnection
    {
        public string? ApiID { get; set; }
        public required string Url { get; set; }
        public required string Type { get; set; }
    }
}
