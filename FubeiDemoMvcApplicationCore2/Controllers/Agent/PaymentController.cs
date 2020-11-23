using System;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Models.Parameter.Agent;
using Com.Fubei.OpenApi.NetCore2.Models.Response.Agent;
using Com.Fubei.OpenApi.NetCore2.Services;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Enums;
using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Fubei.OpenApi.NetCore2.Controllers.Agent
{
    [ApiController]
    public class PaymentController : FubeiApiBaseController
    {
        /// <summary>
        /// 订单号生成服务，对接方需要自己实现
        /// </summary>
        private readonly IOrderService _orderService;
        
        public PaymentController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider) : base(loggerFactory, serviceProvider)
        {
            _orderService = serviceProvider.GetService<IOrderService>();
        }

        // todo: 示例1：使用服务商级扣款接口，进行付款码扣款
        // 可在业务系统中，使用自定义Filter 调用此接口前进行验签操作
        // 以application/x-www-form-urlencoded发送
        [HttpPost, ActionName("agentOrderPay")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<FubeiApiCommonResult<AOrderDetailResultEntity>> OrderPayByAgent(
            [FromForm(Name = "merchant_id")] int? merchantId,
            [FromForm(Name = "auth_code")]string authCode, 
            [FromForm(Name = "total_amount")] decimal totalAmount, 
            [FromForm(Name = "store_id")]int storeId,
            [FromForm(Name = "cashier_id")] int? cashierId)
        {
            return await FubeiOpenApiCoreSdk.PostVendorApiRequestAsync<AOrderDetailResultEntity>("fbpay.order.pay", new AOrderPayParam()
            {
                MerchantOrderSn = _orderService.GenerateOrderId(),
                AuthCode = authCode,
                TotalAmount = totalAmount,
                MerchantId = merchantId,
                StoreId =  storeId,
                CashierId = cashierId
            }, EApiLevel.Vendor);
        }

        // todo: 示例2：使用商户级权限的扣款接口，进行付款码扣款
        // 可在业务系统中，使用自定义Filter 调用此接口前进行验签操作
        // 以application/x-www-form-urlencoded发送
        [HttpPost, ActionName("merchantOrderPay")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<FubeiApiCommonResult<AOrderDetailResultEntity>> OrderPay(
            [FromForm(Name = "auth_code")] string authCode,
            [FromForm(Name = "total_amount")] decimal totalAmount,
            [FromForm(Name = "store_id")] int storeId,
            [FromForm(Name = "cashier_id")] int? cashierId)
        {
            return await FubeiOpenApiCoreSdk.PostVendorApiRequestAsync<AOrderDetailResultEntity>("fbpay.order.pay", new AOrderPayParam()
            {
                MerchantOrderSn = _orderService.GenerateOrderId(),
                AuthCode = authCode,
                TotalAmount = totalAmount,
                StoreId = storeId,
                CashierId = cashierId
            }, EApiLevel.Merchant);
        }

        // todo: 示例1：使用服务商级的订单查询
        // 可在业务系统中，使用自定义Filter 调用此接口前进行验签操作
        // 以application/x-www-form-urlencoded发送
        [HttpPost, ActionName("agentOrderQuery")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<FubeiApiCommonResult<AOrderDetailResultEntity>> OrderQueryByAgent(
            [FromForm(Name = "merchant_id")] int merchantId,
            [FromForm(Name = "merchant_order_sn")] string merchantOrderSn,
            [FromForm(Name = "order_sn")] string orderSn,
            [FromForm(Name = "ins_order_sn")] string insOrderSn)
        {
            return await FubeiOpenApiCoreSdk.PostVendorApiRequestAsync<AOrderDetailResultEntity>("fbpay.order.query", new AOrderQueryParam()
            {
                MerchantId = merchantId,
                MerchantOrderSn = merchantOrderSn,
                OrderSn = orderSn,
                InsOrderSn = insOrderSn
            }, EApiLevel.Vendor);
        }

        // todo: 示例2：使用商户级权限的扣款接口，进行付款码扣款
        // 可在业务系统中，使用自定义Filter 调用此接口前进行验签操作
        // 以application/x-www-form-urlencoded发送
        [HttpPost, ActionName("merchantOrderQuery")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<FubeiApiCommonResult<AOrderDetailResultEntity>> OrderQuery(
            [FromForm(Name = "merchant_order_sn")] string merchantOrderSn,
            [FromForm(Name = "order_sn")] string orderSn,
            [FromForm(Name = "ins_order_sn")] string insOrderSn)
        {
            return await FubeiOpenApiCoreSdk.PostVendorApiRequestAsync<AOrderDetailResultEntity>("fbpay.order.query", new AOrderQueryParam()
            {
                MerchantOrderSn = merchantOrderSn,
                OrderSn = orderSn,
                InsOrderSn = insOrderSn
            }, EApiLevel.Merchant);
        }
    }
}
