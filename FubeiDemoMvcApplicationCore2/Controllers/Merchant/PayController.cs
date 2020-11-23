using System;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Models.Parameter.Merchant;
using Com.Fubei.OpenApi.NetCore2.Models.Response;
using Com.Fubei.OpenApi.NetCore2.Models.Response.Merchant;
using Com.Fubei.OpenApi.NetCore2.Services;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Enums;
using Com.Fubei.OpenApi.Sdk.Models;
using Com.Fubei.OpenApi.Sdk.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Fubei.OpenApi.NetCore2.Controllers.Merchant
{
    [ApiController]
    public class PayController : FubeiApiBaseController
    {
        /// <summary>
        /// 订单号生成服务，对接方需要自己实现
        /// </summary>
        private readonly IOrderService _orderService;
        
        public PayController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
            _orderService = serviceProvider.GetService<IOrderService>();
        }


        // todo: 示例1：采用x-www-form-urlencoded方式
        // 可在业务系统中，使用自定义Filter 调用此接口前进行验签操作
        // 以application/x-www-form-urlencoded发送
        [HttpPost, ActionName("swipePay1")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<FubeiApiCommonResult<OrderPayResultEntity>> SwipePay(
            [FromForm(Name = "auth_code")]string authCode, [FromForm(Name = "total_fee")] decimal totalFee, [FromForm(Name = "store_id")]int? storeId)
        {
            var barcodeType = BarcodeDetector.Instance.GetBarcodeType(authCode);
            if (barcodeType == EBarcodeType.Undetermined)
            {
                // todo: 业务系统自己处理，demo则直接抛出异常
                throw new Exception("付款码错误");
            }

            return await FubeiOpenApiCoreSdk.PostMerchantApiRequestAsync<OrderPayResultEntity>("openapi.payment.order.swipe", new OrderPayParam()
            {
                MerchantOrderSn = _orderService.GenerateOrderId(),
                AuthCode = authCode,
                TotalFee = totalFee,
                StoreId =  storeId,
                Type = (int)barcodeType
            });
        }

        // todo: 示例2：采用application/json方式
        // 该示例使用透传方式进行，json格式和openapi文档中的一致
        [HttpPost, ActionName("swipePay2")]
        [Consumes("application/json")]
        public async Task<FubeiApiCommonResult<OrderPayResultEntity>> SwipePay([FromBody] OrderPayParam param)
        {
            return await FubeiOpenApiCoreSdk.PostMerchantApiRequestAsync<OrderPayResultEntity>("openapi.payment.order.swipe", param);
        }
    }
}
