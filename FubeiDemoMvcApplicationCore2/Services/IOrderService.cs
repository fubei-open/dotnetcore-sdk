namespace Com.Fubei.OpenApi.NetCore2.Services
{
    /// <summary>
    /// 订单Id生成服务
    /// todo: 可以修改这个Service用于生成订单Id
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 业务方实现，用于生成订单号
        /// </summary>
        /// <returns></returns>
        string GenerateOrderId();
    }
}