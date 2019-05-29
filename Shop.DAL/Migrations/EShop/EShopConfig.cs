namespace Shop.DAL.Migrations.EShop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class EShopConfig : DbMigrationsConfiguration<Shop.DAL.DB.EShopContext>
    {
        public EShopConfig()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\EShop";
        }

        protected override void Seed(Shop.DAL.DB.EShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
