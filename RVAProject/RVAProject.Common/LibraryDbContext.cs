using RVAProject.Common.Entities;
using System.Configuration;
using System.Data.Entity;

namespace RVAProject.Common
{
    [DbConfigurationType(typeof(LibraryDbConfiguration))]
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get;set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
