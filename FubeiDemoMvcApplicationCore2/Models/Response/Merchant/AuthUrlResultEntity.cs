using Com.Fubei.OpenApi.Sdk.Models;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.NetCore2.Models.Response.Merchant
{
    public class AuthUrlResultEntity : BaseEntity
    {
        [JsonProperty("authUrl")]
        public string AuthUrl { get; set; }
    }
}