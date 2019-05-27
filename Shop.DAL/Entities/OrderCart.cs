using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class OrderCart
    {
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }

        // public virtual UserModel User { get; set; }
        public virtual IEnumerable<Product> Products{ get; set; }
    }
}
