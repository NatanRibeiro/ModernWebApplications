using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ModernWebStore.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //var container = new UnityContainer();

            //ConfigureDependencyInjection(config, container);
            //ConfigureWebApi(config);

            //ConfigureOAuth(app, container.Resolve<IUserApplicationService>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}