using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.DAL.DB;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repository
{
    public class AuthenticationRepository
    {
        private AuthenticationContext _ctx;

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AuthenticationRepository(AuthenticationContext context)
        {
            _ctx = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
        }

        //public void RoleAddToUser(string UserName, string RoleName)
        //{
        //    ApplicationUser user = _ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //    _userManager.AddToRole(user.Id, RoleName);
        //}
        public ApplicationUser GetApplicationUser(string UserName)
        {
            ApplicationUser user = _ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return user;
        }
        public IdentityRole GetIdentityRole(string RoleName)
        {
            IdentityRole role = _ctx.Roles.Where(n => n.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return role;
        }
        public void DeleteRole(string RoleName)
        {
            IdentityRole role = _ctx.Roles.Where(n => n.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _ctx.Roles.Remove(role);
            _ctx.SaveChanges();
        }
        //public void RemoveRoleFromUser(string UserName, string RoleName)
        //{
        //    ApplicationUser user = _ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //    _userManager.RemoveFromRole(user.Id, RoleName);
        //}
        //public IEnumerable<string> GetRoles(string UserName)
        //{
        //    ApplicationUser user = _ctx.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        //    return _userManager.GetRoles(user.Id).ToList();
        //}

        public void CreateRole(string RoleName)
        {
            _ctx.Roles.Add(new IdentityRole() { Name = RoleName });
            _ctx.SaveChanges();
        }

     

        //public async Task<IdentityResult> RegisterUser(ApplicationUser userModel)
        //{

        //    var user1 = new ApplicationUser
        //    {

        //        UserName = userModel.UserName,

        //    };
        //    var result = await _userManager.CreateAsync(user1, userModel.Password);
        //    return result;
        //}

        //public async Task<IdentityUser> FindUser(string userName, string password)
        //{
        //    IdentityUser user = await _userManager.FindAsync(userName, password);


        //    return user;
        //}

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
