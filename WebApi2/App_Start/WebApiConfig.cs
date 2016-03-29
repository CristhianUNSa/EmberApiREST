using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using System.Configuration;
using System.Web.Cors;
using System.Threading.Tasks;

namespace WebApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
      
        internal static Microsoft.Owin.Cors.CorsOptions GetCorstPolicy()
        {
            var options = new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = (IOwinRequest context) =>
                    {
                        var setting = ConfigurationManager.AppSettings;
                        var policy = new CorsPolicy()
                        {
                            AllowAnyHeader = Convert.ToBoolean(setting.Get("AllowAnyHeader")),
                            AllowAnyMethod = Convert.ToBoolean(setting.Get("AllowAnyMethod")),
                            AllowAnyOrigin = Convert.ToBoolean(setting.Get("AllowAnyOrigin")),
                            SupportsCredentials = true
                        };
                        if (!policy.AllowAnyOrigin)
                        {
                            foreach (string domain in setting.Get("AllowDomains").Split(','))
                            {
                                policy.Origins.Add(domain);
                            }
                        }
                        if (!policy.AllowAnyHeader)
                        {
                            //foreach (string header in setting.Get("AllowHeaders").Split(','))
                            //{
                            //    policy.Headers.Add(header);
                            //}
                        }
                        return Task.FromResult<CorsPolicy>(policy);
                    }
                }
            };
            return options;
        }

    }
}
