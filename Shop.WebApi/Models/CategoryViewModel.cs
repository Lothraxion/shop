using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Show.WebApi.Models
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        public List<string> Sections { get; set; }
    }
}