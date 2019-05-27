using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
      //  public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public int SalesOnCategory { get; set; }
        public Category()
        {
           // Products = new List<Product>();
            Sections = new List<Section>();
        }
    }
}
