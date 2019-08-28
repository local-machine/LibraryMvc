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

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            Book.EditBook(id, book);
            return RedirectToAction("Index");
        }

        // // Delete particular Book by BookId
        // public ActionResult Delete()
        // {
        //     return View();
        // }

        
        public IActionResult Delete(int id)
        {
            Console.WriteLine("Deleting.. from Controller");
            Book.DeleteBook(id);
            return RedirectToAction("Index");
        }

    }
}
