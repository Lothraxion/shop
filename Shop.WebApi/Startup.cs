using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi;
using Microsoft.Owin.Security;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Shop.BLL.BLLNinjectModule;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;
//using Show.WebApi.App_Start;
using Show.WebApi.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Shop.DAL.Interfaces;
using Show.WebApi.Providers;
using Show.WebApi.Util;

[assembly: OwinStartup(typeof(Shop.WebApi.Startup))]
namespace Shop.WebApi
{
    public class Startup
    {
      
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var kernel = NinjectStart.CreateKernel();
            ConfigureOAuth(app,kernel);
            Automap.Configure();
           // GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
           
            app.UseNinjectMiddleware(NinjectStart.CreateKernel).UseNinjectWebApi(config);
        }
      

        public void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(kernel.Get<IUserService>())
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}