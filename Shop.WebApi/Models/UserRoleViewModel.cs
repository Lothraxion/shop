using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Show.WebApi.Models
{
    public class UserRoleViewModel
    {
        [Required]
        [Display(Name = "RoleName")]
        public string RoleName { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}