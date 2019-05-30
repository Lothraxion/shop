using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Shop.BLL.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Сharacteristics { get; set; }
        public int Sales { get; set; }
        public string CategoryName { get; set; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }

    }
}
