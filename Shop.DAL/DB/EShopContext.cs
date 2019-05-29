using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DB
{
    public class EShopContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubSection> SubSections { get; set; }
        public DbSet<OrderCart> OrderCarts { get; set;}
        public EShopContext(string connectionString) : base(connectionString)
        {
           // Database.SetInitializer(new EshopDBInitializer());
        }

        public EShopContext() { Database.SetInitializer(new EshopDBInitializer()); }
    }
}
