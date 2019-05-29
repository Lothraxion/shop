﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {

    
        // [ForeignKey("ProductCart")]
        public int OrderCartId { get; set; }
        public string Password { get; set; }
        //[Required]
        //[Display(Name = "User name")]
        //public string UserName { get; set; }
        //  public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
        // [DataType(DataType.Password)]

    }
}
