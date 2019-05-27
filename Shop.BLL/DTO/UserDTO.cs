using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double ProductsCost { get; set; }
        [DataMember]
        public List<ProductDTO> ProductCart { get; set; }
    }
}
