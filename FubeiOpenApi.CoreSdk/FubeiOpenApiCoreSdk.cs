using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.Sdk.Enums;
using Com.Fubei.OpenApi.Sdk.Models;
using Com.Fubei.OpenApi.Sdk.Utils;
using Com.Fubei.OpenApi.Sdk.Extensions;
using Newtonsoft.Json;

namespace Com.Fubei.OpenApi.Sdk
{
    public class FubeiOpenApiCoreSdk
    {
        private static async Task<T> PostRequestAsync<T>(string url, FubeiBizParam param)
        {
            var requestParam = param.GenerateAsFubeiRequestParam();
            var json = await HttpUtil.PostRequest(url, requestParam);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static bool VerifyFubeiNotification(FubeiApiCommonResult<string> result, string sign, EApiLevel apiLevel)
        {
            var secret = apiLevel == EApiLevel.Merchant
                ? FubeiOpenApiGlobalConfig.Instance.AppSecret
                : FubeiOpenApiGlobalConfig.Instance.VendorSecret;
            
            return FubeiSignatureUtil.Verify(result, secret, sign);
        }

        /// <summary>
        /// 获得Api地址
        /// </summary>
        /// <param name="openApiVersion">接口版本号 1: 开放平台1.0  2: 开放平台2.0</param>
        private static string GetApiUrlByVersion(int openApiVer = 2)
        {
            if (openApiVer == 1)
            {
                return FubeiOpenApiGlobalConfig.Instance.Api_1_0;
            }

            return FubeiOpenApiGlobalConfig.Instance.Api_2_0;
        }

        public static async Task<FubeiApiCommonResult<T>> PostMerchantApiRequestAsync<T>(string method, BaseEntity obj) where T : new()
        {
            return await PostRequestAsync<FubeiApiCommonResult<T>>(GetApiUrlByVersion(1), obj.WithFubeiBizParam(method, EApiLevel.Merchant));
        }

        public static async Task<FubeiApiCommonResult<T>> PostVendorApiRequestAsync<T>(string method, BaseEntity obj, EApiLevel apiLevel = EApiLevel.Vendor) where T : new()
        {
            return await PostRequestAsync<FubeiApiCommonResult<T>>(GetApiUrlByVersion(2), obj.WithFubeiBizParam(method, apiLevel));
        }
    }
}
