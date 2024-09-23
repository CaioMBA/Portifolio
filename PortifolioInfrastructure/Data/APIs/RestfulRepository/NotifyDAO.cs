using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.ContactModels;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioCore.Extensions;

namespace PortifolioInfrastructure.Data.APIs.RestfulRepository
{
    public class NotifyDAO
    {
        private readonly ApiDefaultAccess _api;
        private readonly Utils _utils;
        public NotifyDAO(ApiDefaultAccess api, Utils utils)
        {
            _api = api;
            _utils = utils;
        }

        public string sendNotification(NotificationRequestModel model)
        {
            ApiConnection endpoint = _utils.GetApi("Notifications");

            ApiRequestModel request = new ApiRequestModel()
            {
                Url = endpoint.Url,
                TypeRequest = endpoint.Type,
                Auth = null,
                Headers = null,
                TimeOut = 10,
                Body = model.ToJson()
            };

            var response = _api.ApiRequest(request);

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
