using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Shop.BLL.DTO
{
    [DataContract]
    public class ProductDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Amout { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Сharacteristics { get; set; }
        [DataMember]
        public string SectionName { get; set; }
        [DataMember]
        public string SubSectionName { get; set; }

    }
}
