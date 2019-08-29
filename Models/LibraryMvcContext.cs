using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Models
{
    public class LibraryMvcContext : DbContext{
        public virtual DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books {get; set;}
        public DbSet<AuthorBook> AuthorBook {get; set;}
        public LibraryMvcContext(DbContextOptions options) : base(options) {}
    }
}