namespace RVAProject.Common.Migrations
{
    using RVAProject.Common.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RVAProject.Common.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RVAProject.Common.LibraryDbContext context)
        {
            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Zlatko",
                LastName = "Cikic",
                isAdmin = true,
                Password = "admin",
                Username = "admin"
            });
            context.SaveChanges();
        }
    }
}
