using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Show.WebApi.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int Sales { get; private set; }
        public string Сharacteristics { get; set; }
        public string CategoryName { get; set; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }
    }
}