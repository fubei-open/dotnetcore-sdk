using System;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Models.Parameter.Merchant;
using Com.Fubei.OpenApi.NetCore2.Models.Response;
using Com.Fubei.OpenApi.NetCore2.Models.Response.Merchant;
using Com.Fubei.OpenApi.NetCore2.Services;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Com.Fubei.OpenApi.NetCore2.Controllers.Merchant
{
    [ApiController]
    public class OrderController : FubeiApiBaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
            _orderService = serviceProvider.GetService<IOrderService>();
        }

        [HttpPost, ActionName("h5pay")]
        public async Task<FubeiApiCommonResult<H5PayResultEntity>> H5Pay(
            [FromQuery(Name = "open_id")] string openId, 
            [FromQuery(Name = "sub_open_id")] string subOpenId, 
            [FromQuery(Name = "total_fee")] decimal? totalFee, 
            [FromQuery(Name = "store_id")] int? storeId,
            [FromQuery(Name = "cashier_id")] int? cashierId)
        {
            return await FubeiOpenApiCoreSdk.PostMerchantApiRequestAsync<H5PayResultEntity>("openapi.payment.order.h5pay", new FubeiH5PayParam
            {
                OpenId = openId,
                SubOpenId = subOpenId,
                CashierId = cashierId,
                MerchantOrderSn = _orderService.GenerateOrderId(),
                StoreId = storeId,
                TotalFee = totalFee
            });
        }        
    }
}