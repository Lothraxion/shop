using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    [DataContract]
    public class OrderCartDTO
    {
        public string UserName { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductDTO> Products { get; set; }
      //public List<int> ProductAmounts { get; set; }
    }
}
