using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        


        // Display all Books
        public IActionResult Index()
        {
            var allBook = Book.GetAllBooks();
            return View(allBook);
        }


        // Create new Book
        public ActionResult Create()
        {
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

        // Edit a particular Book by BookId
        public ActionResult Edit(int id)
        {
            var thisBook = Book.GetThisBook(id);
            return View(thisBook);
        }

        [HttpPut]
        public IActionResult Edit(Book book, int id)
        {
            Book.EditBook(book, id);
            return RedirectToAction("Index");
        }

        // Delete particular Book by BookId
        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book.DeleteBook(id);
            return RedirectToAction("Index");
        }

    }
}
