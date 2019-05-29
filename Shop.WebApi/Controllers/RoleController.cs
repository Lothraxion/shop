using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;
using Show.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Show.WebApi.Controllers
{
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        private IUserService UserService;

        public RoleController(IUserService Service)
        {
            UserService = Service;
        }
       
        [HttpPost]
        [Route("CreateRole")]
        public string PostRole([FromBody]RoleViewModel Role)
        {
            try

            {
                UserService.AddRole(Role.RoleName);
                //_repo.AuthRepository.CreateRole(Role.RoleName);
                return Role.RoleName;
               // return Ok();
                
            }
            catch
            {
                return Role.RoleName;
              //  return Ok();
            }
        }
        [Route("RemoveRole")]
        [HttpPost]
        public string RevomeRole([FromBody]RoleViewModel Role)
        {
            try

            {
                UserService.DeleteRole(Role.RoleName);
                return Role.RoleName;

            }
            catch
            {
                return Role.RoleName;
            }
        }
        [Route("DeleteRoleForUser")]
        [HttpPost]
        public void RemoveRole([FromBody] UserRoleViewModel userRole)
        {
            UserService.RemoveRoleFromUser(userRole.UserName, userRole.RoleName);
        }
        [Route("AddRoleToUser")]
        [HttpPost]
        public void RoleAddToUser([FromBody] UserRoleViewModel userRole)
        {
            UserService.AddRoleToUser(userRole.UserName, userRole.RoleName);
        }
        [HttpGet]
        [Route("{UserName:alpha}")]
        public IEnumerable<string> GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var roles = UserService.GetRoles(UserName);
                return roles;
            }
            return null;
        }

    }
}
