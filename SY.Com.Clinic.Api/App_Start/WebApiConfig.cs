using SY.Com.Clinic.Api.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SY.Com.Clinic.Api
{
    /// <summary>
    /// WebApiConfig Class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register Route
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //注册验证过滤器
            config.Filters.Add(new AuthTokenAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
