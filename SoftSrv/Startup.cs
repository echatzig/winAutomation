using Microsoft.Owin;
using Owin;
using System.Web.Http;

namespace SoftSrv
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            // Note: I prefer my routes to be "api/{controller}/{action}" instead of "api/{controller}/{id}"
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
    }
}
