using System.Threading.Tasks;
using Com.Fubei.OpenApi.Sdk.Models;

namespace Com.Fubei.OpenApi.NetCore2.Services
{
    /// <summary>
    /// 服务API请求服务
    /// </summary>
    public interface IFubeiApiRequestService
    {
        /// <summary>
        /// 异步发送请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<T> PostRequestAsync<T>(FubeiBizParam param);
    }
}