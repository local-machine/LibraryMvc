using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using LibraryMvc.Models;
namespace LibraryMvc.ViewModels
{
    public class LibraryCreateViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public IFormFile Photo { get; set; }

        public virtual ICollection<AuthorBook> Authors { get; set; }
        public virtual ICollection<Copy> Copies { get;}
    }
}
