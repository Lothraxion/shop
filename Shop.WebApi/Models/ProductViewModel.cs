using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Show.WebApi.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Enter postitve int number")]
        public int Amount { get; set; }

        [Range(1,double.MaxValue,ErrorMessage ="Enter postitve double number")]
        public double Price { get; set; }

        public int Sales { get; private set; }
        public string Сharacteristics { get; set; }
        public string CategoryName { get; set; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }
    }
}