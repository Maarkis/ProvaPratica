using System.Text.Json.Serialization;

namespace ProvaPratica.Application.Utils
{
    public class BaseResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        
    }
}