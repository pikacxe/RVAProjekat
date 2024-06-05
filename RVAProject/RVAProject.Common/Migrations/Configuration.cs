namespace RVAProject.Common.Migrations
{
    using RVAProject.Common.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RVAProject.Common.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RVAProject.Common.LibraryDbContext context)
        {
            // Create authors
            var authors = new List<Author>
            {
                new Author { Id = Guid.NewGuid(), FullName = "Ivo Andric", PenName = "Ivo", HasNobelPrize = true },
                new Author { Id = Guid.NewGuid(), FullName = "Mesa Selimovic", PenName = "Mesa", HasNobelPrize = true },
                new Author { Id = Guid.NewGuid(), FullName = "Danilo Kis", PenName = "Danilo", HasNobelPrize = false },
                new Author { Id = Guid.NewGuid(), FullName = "Milos Crnjanski", PenName = "Milos", HasNobelPrize = false },
                new Author { Id = Guid.NewGuid(), FullName = "Bora Stankovic", PenName = "Bora", HasNobelPrize = false }
            };
            context.Authors.AddRange(authors);

            // Create users
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), FirstName = "Zlatko", LastName = "Cikic", isAdmin = true, Password = "admin", Username = "admin" },
                new User { Id = Guid.NewGuid(), FirstName = "Nikola", LastName = "Nikolic", isAdmin = false, Password = "user", Username = "user" }
            };
            context.Users.AddRange(users);

            // Create publishers
            var publishers = new List<Publisher>
            {
                new Publisher { Id = Guid.NewGuid(), Name = "Vulkan", Address = "Bulevar Kralja Aleksandra 17", Email = "vulkan@vulkan.com" },
                new Publisher { Id = Guid.NewGuid(), Name = "Laguna", Address = "Bulevar Kralja Aleksandra 17", Email = "laguna@laguna.com" },
                new Publisher { Id = Guid.NewGuid(), Name = "Dereta", Address = "Bulevar Kralja Aleksandra 17", Email = "dereta@dereta.com" }
            };
            context.Publishers.AddRange(publishers);

            // Create books
            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Na Drini cuprija",
                    Description = "Na Drini cuprija je roman Ive Andrica, dobitnika Nobelove nagrade za književnost 1961. godine.",
                    Publisher = publishers.First(p => p.Name == "Laguna"),
                    Authors = new List<Author> { authors.First(a => a.FullName == "Ivo Andric") }
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Dervis i smrt",
                    Description = "Dervis i smrt je roman Mese Selimovica.",
                    Publisher = publishers.First(p => p.Name == "Vulkan"),
                    Authors = new List<Author> { authors.First(a => a.FullName == "Mesa Selimovic") }
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Bastard",
                    Description = "Bastard je roman Danila Kisa.",
                    Publisher = publishers.First(p => p.Name == "Dereta"),
                    Authors = new List<Author> { authors.First(a => a.FullName == "Danilo Kis") }
                }
            };
            context.Books.AddRange(books);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
