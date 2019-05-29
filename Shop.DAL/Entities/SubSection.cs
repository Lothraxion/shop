using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class SubSection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int SalesOnSubSection { get; set; }

        public SubSection()
        {
            Products = new List<Product>();

        }
    }
}
