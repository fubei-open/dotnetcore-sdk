using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Fubei.OpenApi.Sdk
{
    public class FubeiOpenApiGlobalConfig
    {
        public static FubeiOpenApiGlobalConfig Instance = new FubeiOpenApiGlobalConfig();

        /// <summary>
        /// 商户Api地址
        /// </summary>
        public string Api_1_0 { get; set; }

        /// <summary>
        /// 商户Api AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户Api AppSecret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 公众号支付H5地址
        /// </summary>
        public string PayH5Page { get; set; }

        /// <summary>
        /// 服务商api地址
        /// </summary>
        public string Api_2_0 { get; set; }

        /// <summary>
        /// 服务商SN
        /// </summary>
        public string VendorSn { get; set; }

        /// <summary>
        /// 服务商AppSecret
        /// </summary>
        public string VendorSecret { get; set; }
    }
}
