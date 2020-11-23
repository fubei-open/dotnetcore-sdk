using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.NetCore2.Models.Parameter
{
    public class FubeiNotificationParam : BaseEntity
    {
        [JsonProperty("result_code")]
        [FromForm(Name = "result_code")]
        public string ResultCode { get; set; }

        [JsonProperty("result_message")]
        [FromForm(Name = "result_message")]
        public string ResultMessage { get; set; }

        [JsonProperty("data")]
        [FromForm(Name = "data")]
        public string Data { get; set; }

        [JsonIgnore]
        public string AppSecret { get; set; }
    }
}