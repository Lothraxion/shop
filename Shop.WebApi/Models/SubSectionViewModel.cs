using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Show.WebApi.Models
{
    public class SubSectionViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SectionName { get; set; }
        public List<string> Products { get; set; }
    }
}