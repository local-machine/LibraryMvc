using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var allBook = Book.GetAllBooks();
            return View(allBook);
        }

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

        public IActionResult Details(int id)
        {
            var thisBook = Book.GetThisBook(id);
            return View(thisBook);
        }
    }
}
