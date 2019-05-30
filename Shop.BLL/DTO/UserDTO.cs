using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public double ProductsCost { get; set; }
        public List<ProductDTO> ProductCart { get; set; }
    }
}
