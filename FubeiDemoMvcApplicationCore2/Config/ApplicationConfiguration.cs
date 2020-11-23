namespace Com.Fubei.OpenApi.NetCore2.Config
{
    /// <summary>
    /// 应用配置，
    /// 对应appsettings.json中的ApplicationConfiguration
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        /// 商户Api地址
        /// </summary>
        public string Api { get; set; }

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
        public string Api20 { get; set; }

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