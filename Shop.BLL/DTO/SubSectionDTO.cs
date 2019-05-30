using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class SubSectionDTO
    {
        public string Name { get; set; }
        public string SectionName { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
