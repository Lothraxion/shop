using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Pirce { get; set; }
        public string Сharacteristics { get; set; }
        public int Amount { get; set; }
        public int Sales { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public virtual SubSection SubSection { get; set; }
        [Required]
        public virtual Section Section { get; set; }

    }
}
