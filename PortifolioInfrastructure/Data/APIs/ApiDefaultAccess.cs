using PortifolioCore.Entities.Models.GeneralSettingsModels;
using System.Text;

namespace PortifolioInfrastructure.Data.APIs
{
    public class ApiDefaultAccess
    {
        public HttpResponseMessage ApiRequest(ApiRequestModel ApiRequest)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpMethod Method = ApiRequest.TypeRequest.ToUpper().Trim() switch
                {
                    "GET" => HttpMethod.Get,
                    "POST" => HttpMethod.Post,
                    "PUT" => HttpMethod.Put,
                    "DELETE" => HttpMethod.Delete,
                    "HEAD" => HttpMethod.Head,
                    "OPTIONS" => HttpMethod.Options,
                    "TRACE" => HttpMethod.Trace,
                    "PATCH" => HttpMethod.Patch,
                    _ => throw new Exception("Nenhum Método Aceito"),
                };
                var request = new HttpRequestMessage(Method, ApiRequest.Url);



                if (ApiRequest.TimeOut != null)
                {
                    httpClient.Timeout = TimeSpan.FromSeconds((double)ApiRequest.TimeOut);
                }
                if (ApiRequest.Auth != null)
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(ApiRequest.Auth.Type, ApiRequest.Auth.Authorization);
                }
                if (ApiRequest.Headers != null)
                {
                    foreach (var header in ApiRequest.Headers!)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (!String.IsNullOrEmpty(ApiRequest.Body))
                {
                    request.Content = new StringContent(ApiRequest.Body, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? response = httpClient.SendAsync(request).Result;


                return response;
            }

        }
    }
}
