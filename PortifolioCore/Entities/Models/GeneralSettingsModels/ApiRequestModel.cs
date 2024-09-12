using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortifolioCore.Entities.Models.GeneralSettingsModels
{
    public class ApiRequestModel
    {
        public required string Url { get; set; }
        public required string TypeRequest { get; set; }
        public string? Body { get; set; }
        public double? TimeOut { get; set; }
        public Dictionary<string, dynamic?>? Headers { get; set; }
        public AuthApiModel? Auth { get; set; }
    }

    public class AuthApiModel
    {
        public required string Type { get; set; }
        public required string Authorization { get; set; }
    }
}
