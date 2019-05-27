using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Shop.DAL.Interfaces;
using Shop.DAL.UnitOfWork;

namespace Shop.BLL.BLLNinjectModule
{
  public  class ServiceNinjectModule : NinjectModule
    {
        private string ShopConnection;
        public ServiceNinjectModule(string connection)
        {
            this.ShopConnection = connection;
            
        }
        public override void Load()
        {
            Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument(ShopConnection);
        }
    }
}
