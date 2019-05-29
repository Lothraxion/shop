using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.BLL.Interfaces;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
   public class UserService:IUserService
    {
        public IAuthenticationUoW UoW { get; private set; }
        public UserService(IAuthenticationUoW unit)
        {
            this.UoW = unit;
        }
        public void AddRole(string RoleName)
        {
            UoW.AuthRepository.CreateRole(RoleName);
        }
        //public void RemoveRole(string RoleName)
        //{
        //    UoW.AuthRepository.DeleteRole(RoleName);
        //}
        public async Task<IdentityResult> RegisterUser(ApplicationUser userModel)
        {
            var user1 = new ApplicationUser
            {
                UserName = userModel.UserName,
            };
            var result = await UoW._userManager.CreateAsync(user1, userModel.Password);
            return result;
        }
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await UoW._userManager.FindAsync(userName, password);
            return user;
        }
        public void AddRoleToUser(string RoleName,string UserName)
        {
            ApplicationUser user = UoW.AuthRepository.GetApplicationUser(UserName);
            UoW._userManager.AddToRole(user.Id, RoleName);
        }
        public void DeleteRole(string RoleName)
        {
            UoW.AuthRepository.DeleteRole(RoleName);
        }
        public void RemoveRoleFromUser(string UserName, string RoleName)
        {
            ApplicationUser user = UoW.AuthRepository.GetApplicationUser(UserName);
            UoW._userManager.RemoveFromRole(user.Id, RoleName);
        }
        public IEnumerable<string> GetRoles(string UserName)
        {
            ApplicationUser user = UoW.AuthRepository.GetApplicationUser(UserName);
            return UoW._userManager.GetRoles(user.Id).ToList();
        }
        public void Dispose()
        {
            UoW.Dispose();
        }
    }
}
