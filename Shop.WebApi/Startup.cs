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

[assembly: OwinStartup(typeof(Shop.WebApi.Startup))]
namespace Shop.WebApi
{
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    //NinjectWebCommon.Start();
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    HttpConfiguration config = new HttpConfiguration();
        //    WebApiConfig.Register(config);
        //    app.UseNinjectWebApi(config);
        //    //app.UseWebApi(config);
        //   // app.UseNinjectMiddleware
        //}
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var kernel = CreateKernel();
            ConfigureOAuth(app,kernel);
            Automap.Configure();
           // GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
           
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
        }
        private static StandardKernel CreateKernel()
        {
            var modules = new INinjectModule[] { new ServiceNinjectModule("ShopConnection"),
                new AuthenticationNinjectModule("AuthenticationConnection")};
            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Load(Assembly.GetExecutingAssembly());
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
           
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IOrderService>().To<OrderService>();
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