using Ninject.Modules;
using Shop.DAL.Interfaces;
using Shop.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.BLLNinjectModule
{
   public class AuthenticationNinjectModule : NinjectModule
    {
        private string AuthenticationConnection;
        public AuthenticationNinjectModule(string AuthenticationConnection)
        {
            this.AuthenticationConnection = AuthenticationConnection;
        }
        public override void Load()
        {
            Bind<IAuthenticationUoW>().To<AuthenticationUoW>().WithConstructorArgument(AuthenticationConnection);
        }
    }
    
}
