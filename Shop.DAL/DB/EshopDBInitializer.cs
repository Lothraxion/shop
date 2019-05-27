using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DB
{
    class EshopDBInitializer : DropCreateDatabaseAlways<EShopContext>
    {
        protected override void Seed(EShopContext context)
        {
            Category category = new Category { Name = "Technic" };
            Section section = new Section { Name = "Hardware", Category = category };
            SubSection subSection = new SubSection { Name = "Processors", Section = section };
            Product product1 = new Product { Name = "Intel Core 2 Duo", Сharacteristics = "2 yadra 2 giga", Section = section, SubSection = subSection, Category = category,Pirce=31.321 };
            Product product2 = new Product { Name = "AMD Ryzen 5 1600", Сharacteristics = "2 yadra 2 giga", Section = section, SubSection = subSection, Category = category, Pirce = 332131.321 };
            Product product3 = new Product { Name = "AMD Ryzen 3 1400", Сharacteristics = "2 yadra 2 giga", Section = section, SubSection = subSection, Category = category, Pirce = 33222231.321 };
            Product product4 = new Product { Name = "AMD Ryzen 5 1600x", Сharacteristics = "2 yadra 2 giga", Section = section, SubSection = subSection, Category = category, Pirce = 331.321 };
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);

            base.Seed(context);
        }
    }
}
