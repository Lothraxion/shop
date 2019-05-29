using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderCart
    {
        [Key]
        public int Id { get; set; }
      //  [ForeignKey("User")]
        public int? UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual ICollection<Product> Products{ get; set; }
        public double TotalPrice { get; set; }

        public OrderCart()
        {
            this.Products = new List<Product>();
        }
    }
}
