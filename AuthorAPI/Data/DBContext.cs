using AuthorAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Data
{
    public class DBContext : DbContext
    {
        
        public DbSet<Author> Authors { set; get; }
        
        public DbSet<Book> Books { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source = identifier.db");
        }
        
    }
}