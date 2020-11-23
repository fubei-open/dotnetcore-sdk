using System;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Config;
using Com.Fubei.OpenApi.NetCore2.Services;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Enums;
using Com.Fubei.OpenApi.Sdk.Extensions;
using Com.Fubei.OpenApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Com.Fubei.OpenApi.NetCore2.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FubeiApiBaseController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected ILoggerFactory LoggerFactory;
        protected IServiceScope ServiceScope;
        
        public FubeiApiBaseController(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            Logger = loggerFactory.CreateLogger(GetType().FullName);
            ServiceScope = serviceProvider.GetService<IServiceScope>();
        }
    }
}