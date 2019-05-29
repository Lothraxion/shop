using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual OrderCart Cart { get; set; }

        //public double ProductsCost { get; set; }
        //public virtual ICollection<Product> ProductCart { get; set; }
        //public User()
        //{
        //    this.ProductCart = new List<Product>();
        //}
    }
}
