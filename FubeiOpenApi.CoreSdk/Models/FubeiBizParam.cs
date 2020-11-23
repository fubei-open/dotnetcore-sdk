using Com.Fubei.OpenApi.Sdk.Enums;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.Sdk.Models
{
    /// <summary>
    /// 付呗基本业务参数（带openapi method）
    /// </summary>
    public class FubeiBizParam
    {
        internal FubeiBizParam(string method, BaseEntity obj, EApiLevel apiLevel)
        {
            this.Method = method;
            this.BizContent = obj;
            this.ApiLevel = apiLevel;
        }

        public EApiLevel ApiLevel { get; }

        public string Method { get; }

        public BaseEntity BizContent { get; }
    }
    
    public static class FubeiBizParamExtension
    {
        public static FubeiBizParam WithFubeiBizParam<T>(this T a, string method, EApiLevel apiLevel) where T : BaseEntity
        {
            return new FubeiBizParam(method, a, apiLevel);
        }
    }
}