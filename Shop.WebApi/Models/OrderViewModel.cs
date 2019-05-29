using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Show.WebApi.Models
{
    public class OrderViewModel
    {
        public string UserName { get; set; }
        public List<string> productNames { get; set; }
       // public List<int> ProductAmounts { get; set; }
        public double TotalPrice { get; set; }
    }
}