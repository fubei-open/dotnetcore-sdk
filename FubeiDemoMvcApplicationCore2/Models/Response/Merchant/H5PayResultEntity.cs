using Com.Fubei.OpenApi.Sdk.Models;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.NetCore2.Models.Response.Merchant
{
    public class H5PayResultEntity : BaseEntity
    {
        [JsonProperty("prepay_id")]
        public string PrepayId { get; set; }

        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }

        [JsonProperty("merchant_order_sn")]
        public string MerchantOrderSn { get; set; }
    }
}