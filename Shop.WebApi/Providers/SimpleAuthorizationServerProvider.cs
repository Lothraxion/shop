using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using Shop.BLL.Interfaces;
using Shop.DAL.Constants;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Show.WebApi.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService service;
        public SimpleAuthorizationServerProvider(IUserService uoW)
        {
            service = uoW;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
          
            IdentityUser user = await service.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            IdentityUserRole role = new IdentityUserRole();
            user.Roles.Contains(role);
            var user1 = await service.FindUser(context.UserName, context.Password);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            foreach (var roles in service.GetRoles(user.UserName))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, roles));
            }
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(identity);

        }
    }
}