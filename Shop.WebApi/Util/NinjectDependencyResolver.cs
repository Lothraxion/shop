using Ninject;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Show.WebApi.Util
{
    public class NinjectDependencyResolver : IDependencyScope, IDisposable
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public void Dispose()
        {
            Dispose();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IOrderService>().To<OrderService>();
        }
    }
}