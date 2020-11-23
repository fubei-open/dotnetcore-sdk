using Com.Fubei.OpenApi.Sdk.Models;

namespace Com.Fubei.OpenApi.NetCore2.Services
{
    /// <summary>
    /// 付呗开放平台，签名生成服务
    /// </summary>
    public interface IFubeiSignatureService
    {
        /// <summary>
        /// 生成付呗请求参数(带签名)
        /// </summary>
        /// <param name="bizParam"></param>
        /// <returns></returns>
        FubeiRequestParam GenerateFubeiRequestParam(FubeiBizParam bizParam);

        /// <summary>
        ///  验证签名
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        bool VerifyFubeiNotification(FubeiApiCommonResult<string> result, string sign);
    }
}