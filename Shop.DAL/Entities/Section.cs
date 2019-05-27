using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    public class Section
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<SubSection> SubSections { get; set; }
        public int SalesOnSection { get; set; }

        public Section()
        {
            SubSections = new List<SubSection>();

        }
    }
}
