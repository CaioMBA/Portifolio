using System.Text;
using System.Text.Json;

namespace PortifolioCore.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJson(this Object obj)
        {
            var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(obj, new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Encoding.UTF8.GetString(jsonBytes);
        }
    }
}
