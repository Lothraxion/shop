using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Show.WebApi.Models
{
    public class AddToOrderViewModel
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        [Display(Name ="Amount")]
        [Range(1,int.MaxValue,ErrorMessage ="product amount must be more than 1")]
        public int Amount { get; set; }
        public string UserName { get; set; }
    }
}