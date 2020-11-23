using System;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Models.Parameter.Merchant;
using Com.Fubei.OpenApi.NetCore2.Models.Response.Merchant;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Com.Fubei.OpenApi.NetCore2.Controllers.Merchant
{
    public class AuthController : FubeiApiBaseController
    {
        public AuthController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
        }

        [HttpGet, ActionName("authorize")]
        public async Task<FubeiApiCommonResult<AuthUrlResultEntity>> Auth([FromQuery(Name = "returnUrl")]string url, [FromQuery(Name = "StoreId")]int storeId)
        {
            var param = new FubeiAuthorizeParam
            {
                Url = url,
                StoreId = storeId
            };
            return await FubeiOpenApiCoreSdk.PostMerchantApiRequestAsync<AuthUrlResultEntity>("openapi.payment.auth.auth", param);
        }
    }
}