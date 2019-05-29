using Microsoft.AspNet.Identity;
using Shop.DAL.Entities;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
   public interface IAuthenticationUoW:IDisposable
    {
        AuthenticationRepository AuthRepository { get; }
        UserManager<ApplicationUser> _userManager { get; }
        void CommitChanges();

    }
}
