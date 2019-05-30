using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Shop.BLL.BLLNinjectModule;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Ninject.Web.WebApi;
namespace Show.WebApi.Util
{
    public class NinjectStart
    {
        public static StandardKernel CreateKernel()
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
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ISectionService>().To<SectionService>();
            kernel.Bind<ISubSectionService>().To<SubSectionService>();
        }
    }
  
}
