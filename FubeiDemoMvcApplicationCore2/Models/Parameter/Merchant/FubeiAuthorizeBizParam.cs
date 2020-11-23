using Com.Fubei.OpenApi.Sdk.Models;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.NetCore2.Models.Parameter.Merchant
{
    public class FubeiAuthorizeParam : BaseEntity
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("store_id")]
        public int StoreId { get; set; }
    }
}