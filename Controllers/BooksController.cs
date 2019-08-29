using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;
using System;

namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        // Display all Books
        public IActionResult Index()
        {
            var allBook = Book.GetAllBooks();
            //return View(_db.Books.ToList());
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
            // var thisBook = _db.Books
            // .Include(Book => Book.Authors)
            // .ThenInclude(JsonPatchExtensions => JsonPatchExtensions.Author)
            // .FirstOrDefault(Book => BookId == id);
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
