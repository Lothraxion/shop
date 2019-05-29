using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.DB;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.UnitOfWork
{
    public class AuthenticationUoW : IAuthenticationUoW
    {
        private readonly AuthenticationContext _Authcontext; 
        public AuthenticationRepository AuthRepository => new AuthenticationRepository(_Authcontext);
        public UserStore<ApplicationUser> Store => new UserStore<ApplicationUser>(_Authcontext);
        UserManager<ApplicationUser> IAuthenticationUoW._userManager => new UserManager<ApplicationUser>(Store);

        //UserStore<ApplicationUser> test; 
        public UserManager<ApplicationUser> _userManager;
        public AuthenticationUoW(string ConnectionString)
        {
            _Authcontext = new AuthenticationContext(ConnectionString);
           // _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Authcontext));
        }
        public void CommitChanges()
        {
            _Authcontext.SaveChanges();
        }

        public void Dispose()
        {
            _Authcontext.Dispose();
        }
    }
}
