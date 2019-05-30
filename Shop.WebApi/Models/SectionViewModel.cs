using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Show.WebApi.Models
{
    public class SectionViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<string> SubSections { get; set; }
    }
}