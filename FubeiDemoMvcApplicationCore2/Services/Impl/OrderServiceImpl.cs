using System;
using Com.Fubei.OpenApi.Sdk.Utils;

namespace Com.Fubei.OpenApi.NetCore2.Services.Impl
{
    public class OrderServiceImpl : IOrderService
    {
        private const string Pattern = "yyyyMMddHHmmssfff";

        public string GenerateOrderId()
        {
            return $"{DateTime.Now.ToString(Pattern)}{RandomStringUtil.RandomNumeric(8)}";
        }
    }
}