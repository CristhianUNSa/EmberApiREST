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
using System.Web.Http.Routing;

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
            // esto hay que agregar para que no me de error de cors desde el proyecto ember
            config.EnableCors();            

            /* ESTE ES EL METODO ORIGINAL.. ASI SE CREA POR DEFAULT*/
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            string alphanumeric = @"^[a-zA-Z]+[a-zA-Z0-9_]*$";
            /* ESTO ES PARA QUE FUNQUE EL api/people/otroname ASI AGREGO EL METODO QUE QUIERO  */           

            config.Routes.MapHttpRoute(
                name: "DefaultApiControllerAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: null,
                constraints: new { action = alphanumeric } // action must start with character
            );
            /* ESTO ES PARA QUE FUNQUE EL api/people COMO EL POR DEFECTO  */
            config.Routes.MapHttpRoute(
                name: "DefaultApiControllerGet",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiControllerPost",
            //    routeTemplate: "api/{controller}",
            //    defaults: new { action = "Post" },
            //    constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiControllerPut",
            //    routeTemplate: "api/{controller}",
            //    defaults: new { action = "Put" },
            //    constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiControllerDelete",
            //    routeTemplate: "api/{controller}",
            //    defaults: new { action = "Delete" },
            //    constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            //);







            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));//esto es para que retorne JSON
        }      

    }
}
