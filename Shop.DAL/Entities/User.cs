using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ProductsCost { get; set; }
        public virtual ICollection<Product> ProductCart { get; set; }
        public User()
        {
            this.ProductCart = new List<Product>();
        }
    }
}
