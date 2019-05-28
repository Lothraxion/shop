using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DB
{
   public class AuthenticationContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<UserModel> Users { get; set; }
        public AuthenticationContext(string connectionString)
          : base(connectionString)
        {
        }

        public AuthenticationContext()
        {
            Database.SetInitializer<AuthenticationContext>(new AuthenticationDBInitializer());
        }
    }
}
