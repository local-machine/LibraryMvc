using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet <AuthorBook> AuthorBooks {get; set;}

         public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public LibraryContext()
        {

        }
    }
}