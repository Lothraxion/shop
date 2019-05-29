using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DB
{
    class AuthenticationDBInitializer: DropCreateDatabaseAlways<AuthenticationContext>
    {
        protected override void Seed(AuthenticationContext context)
        {
          //  var manager = new UserManager<UserModel>(new UserStore<UserModel>(new AuthenticationContext()));

          //  UserModel admin = new UserModel { UserRoles = "Admin", UserName = "admin", Password = "adminadmin" };
            //UserModel user = new UserModel { UserRoles = "User", UserName = "user", Password = "useruser" };
            //UserModel manager = new UserModel { UserRoles = "Manager", UserName = "manager", Password = "managermanager" };
           // context.Users.Add(admin);
//context.Us/ers.Add(user);
            //context.Users.Add(manager);
            base.Seed(context);
        }
    }
}
