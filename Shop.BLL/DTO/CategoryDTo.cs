using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Shop.BLL.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public List<SectionDTO> Sections { get; set; }
    }
}
