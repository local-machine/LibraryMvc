using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;


namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;
        
        // Display all Books
        public IActionResult Index()
        {
            var allBook = Book.GetAllBooks();
            return View(allBook);
        }


        // Create new Book
        public ActionResult Create()
        {
           ViewBag.AuthorId = new SelectList(Author.GetAllAuthors(), "AuthorId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            Book.CreateBook(book);
            return RedirectToAction("Index");
        }

        // Display particular Book by BookId
        public IActionResult Details(int id)
        {
            var thisBook = Book.GetThisBook(id);
            return View(thisBook);
        }

        //Edit a particular Book by BookId
        public IActionResult Edit(int id)
        {
            var particularBook = Book.GetThisBook(id);
            return View(particularBook);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            Book.EditBook(id, book);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Book.DeleteBook(id);
            return RedirectToAction("Index");
        }

    }
}
