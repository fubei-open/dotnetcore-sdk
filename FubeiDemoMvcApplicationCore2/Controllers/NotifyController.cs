using System;
using Com.Fubei.OpenApi.NetCore2.Models.Parameter;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Enums;
using Com.Fubei.OpenApi.Sdk.Extensions;
using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.NetCore2.Controllers
{
    /// <summary>
    /// 付呗通知回调
    /// </summary>
    public class NotifyController : FubeiApiBaseController
    {
        public NotifyController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
        }

        /// <summary>
        /// 开放平台1.0通知回调
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/notify")]
        public string MerchantApiNotify([FromForm] FubeiNotificationParam p, [FromForm(Name = "sign")] string sign)
        {
            var valid = FubeiOpenApiCoreSdk.VerifyFubeiNotification(new FubeiApiCommonResult<string>
            {
                Data = p.Data,
                ResultCode = p.ResultCode,
                ResultMessage = p.ResultMessage
            }, sign, EApiLevel.Merchant);
            if (valid)
            {
                Logger.LogInformation("Notification [VALID] => {0}, Sign: {1}", p.SerializeAsJson());
            }
            else
            {
                Logger.LogWarning("Notification [INVALID] => {0}, Sign: {1}", p.SerializeAsJson(), sign);
            }
            return "SUCCESS";
        }

        /// <summary>
        /// 开放平台2.0通知回调
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/notify2")]
        public string AgentApiNotify([FromForm] FubeiNotificationParam p, [FromForm(Name = "sign")] string sign)
        {
            var valid = FubeiOpenApiCoreSdk.VerifyFubeiNotification(new FubeiApiCommonResult<string>
            {
                Data = p.Data,
                ResultCode = p.ResultCode,
                ResultMessage = p.ResultMessage
            }, sign, EApiLevel.Vendor);
            if (valid)
            {
                Logger.LogInformation("Notification [VALID] => {0}, Sign: {1}", p.SerializeAsJson());
            }
            else
            {
                Logger.LogWarning("Notification [INVALID] => {0}, Sign: {1}", p.SerializeAsJson(), sign);
            }
            return "SUCCESS";
        }
    }
}