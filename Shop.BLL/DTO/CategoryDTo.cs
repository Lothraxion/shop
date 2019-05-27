using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Shop.BLL.DTO
{
    [DataContract]
    public class CategoryDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<SectionDTO> Sections { get; set; }
    }
}
