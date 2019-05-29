using Microsoft.AspNet.Identity;
using Shop.BLL.Interfaces;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repository;
using Show.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace Show.WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IUserService service;

        public AccountController(IUserService repository)
        {
            service = repository;
            
        }
        [AllowAnonymous]
        [Route("")]
        public IEnumerable<string> GetUser()
        {
            List<string> user = new List<string>();
            user.Add(User.Identity.Name);
            if (User.IsInRole("Admin"))
                user.Add("Admin");
            if (User.IsInRole("User"))
                user.Add("User");
            if (User.IsInRole("Manager"))
                user.Add("Manager");
          

            return user;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          var appuser=AutoMapper.Mapper.Map<RegisterViewModel, ApplicationUser>(userModel);
            IdentityResult result = await service.RegisterUser(appuser);
          //  Roles.AddUserToRole(userModel.UserName, "User");

           IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
