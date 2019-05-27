using Shop.DAL.DB;
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

        public AuthenticationUoW(string ConnectionString)
        {
            _Authcontext = new AuthenticationContext(ConnectionString);
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
