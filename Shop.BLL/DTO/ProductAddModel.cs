using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
   public class ProductAddModel
    {
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public int Amount { get; set; }

    }
}
