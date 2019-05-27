using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DB
{
   public class AuthenticationContext: IdentityDbContext<IdentityUser>
    {

        public AuthenticationContext(string connectionString)
          : base(connectionString)
        {

        }
    }
}
