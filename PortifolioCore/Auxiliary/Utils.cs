using PortifolioCore.Entities.Models.GeneralSettingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortifolioCore.Auxiliary
{
    public class Utils
    {
        private readonly AppSettingsModel _appSettings;
        public Utils(AppSettingsModel appSettings)
        {
            _appSettings = appSettings;
        }

        public DataBaseConnection GetDataBase(string DataBaseID)
        {
            DataBaseConnection? Conection = (from v in _appSettings.DataBaseConnections
                                             where v.DataBaseID == DataBaseID
                                             select v).FirstOrDefault();
            if (Conection == null)
            {
                throw new Exception($"API not found using Id: {DataBaseID}");
            }

            return Conection;
        }

        public ApiConnection GetApi(string ApiID)
        {
            ApiConnection? Conection = (from v in _appSettings.ApiConnections
                                        where v.ApiID == ApiID
                                        select v).FirstOrDefault();
            if (Conection == null)
            {
                throw new Exception($"API not found using Id: {ApiID}");
            }

            return Conection;
        }
    }
}
