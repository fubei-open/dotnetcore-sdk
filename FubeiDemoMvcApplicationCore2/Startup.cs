using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Fubei.OpenApi.NetCore2.Config;
using Com.Fubei.OpenApi.NetCore2.Services;
using Com.Fubei.OpenApi.NetCore2.Services.Impl;
using Com.Fubei.OpenApi.Sdk;
using Com.Fubei.OpenApi.Sdk.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Com.Fubei.OpenApi.NetCore2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InitConfiguration(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Adds services required for using options.
            services.AddOptions();
            
            // todo: 在此添加自定义Service
            services.AddSingleton<IOrderService, OrderServiceImpl>();

            // todo: 用作DEMO测试接口使用，正式环境请注释Swagger-ui
            // swagger-ui
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fubei OpenApi Tester", Description = "Powered by Asp.Net Core MVC 2.2", Version = "2.2" });
            });
            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // todo: 用作DEMO测试接口使用，正式环境请注释swagger-ui
            // swagger-ui
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fubei API V1");
            });
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="configuration"></param>
        private void InitConfiguration(IConfiguration configuration)
        {
            var appConfig = configuration.GetSection(typeof(ApplicationConfiguration).Name).Get<ApplicationConfiguration>();
            var globalConfig = FubeiOpenApiGlobalConfig.Instance;
            // 商户级调用接口
            globalConfig.Api_1_0 = appConfig.Api;
            globalConfig.AppId = appConfig.AppId;
            globalConfig.AppSecret = appConfig.AppSecret;
            globalConfig.PayH5Page = appConfig.PayH5Page;
            // 代理商/服务商级调用接口
            globalConfig.Api_2_0 = appConfig.Api20;
            globalConfig.VendorSn = appConfig.VendorSn;
            globalConfig.VendorSecret = appConfig.VendorSecret;
        }
    }
}
