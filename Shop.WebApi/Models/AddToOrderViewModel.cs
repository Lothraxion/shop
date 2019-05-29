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
        public int Amount { get; set; }
        public string UserName { get; set; }
    }
}