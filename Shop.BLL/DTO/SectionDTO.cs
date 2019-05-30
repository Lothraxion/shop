using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.DTO
{
    public class SectionDTO
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public List<SubSectionDTO> SubSections { get; set; }

    }
}
