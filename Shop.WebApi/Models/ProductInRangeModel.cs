using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Show.WebApi.Models
{
    public class ProductInRangeModel
    {
        [Required]
        [Range(0,int.MaxValue, ErrorMessage ="Enter positive value for minimum price")]
        public int bot { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Enter positive value for maximum price")]
        public int top { get; set; }
    }
}