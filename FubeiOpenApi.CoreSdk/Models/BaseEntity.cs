using System;

namespace Com.Fubei.OpenApi.Sdk.Models
{
    /// <summary>
    /// 类型限定，方便后续扩展
    /// </summary>
    public interface IBaseModel
    {
    }

    /// <summary>
    /// 类型限定，方便后续扩展
    /// </summary>
    [Serializable]
    public class BaseEntity : IBaseModel
    {
        public static readonly BaseEntity Empty = new BaseEntity();
    }
}
