namespace DimensaoTeste.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using DimensaoTeste.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DimensaoTeste.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DimensaoTeste.Models.ApplicationDbContext";
        }

        protected override void Seed(DimensaoTeste.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AddUsuarios(context);
        }


        void AddUsuarios(DimensaoTeste.Models.ApplicationDbContext context)
        {
            var user = new ApplicationUser { UserName= "usuario@teste.com" };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            um.Create(user, "password");
            
        }
    }
}
