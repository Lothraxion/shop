namespace Shop.DAL.Migrations.AuthenticationContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AuthConfig : DbMigrationsConfiguration<Shop.DAL.DB.AuthenticationContext>
    {
        public AuthConfig()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\AuthenticationContext";
        }

        protected override void Seed(Shop.DAL.DB.AuthenticationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
