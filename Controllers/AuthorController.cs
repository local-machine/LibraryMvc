using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;
using System;

namespace LibraryMvc.Controllers
{
    public class AuthorsController : Controller
    {
        // Display All Authors
        public IActionResult Index()
        {
            var allAuthors = Author.GetAllAuthors();
            return View(allAuthors);
        }

        // Create new Author
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            Author.CreateAuthor(author);
            return RedirectToAction("Index");
        }

        // View details of particular Author by AuthorId
        public IActionResult Details(int id)
        {
            var thisAuthor = Author.GetThisAuthor(id);
            return View(thisAuthor);
        }


        // Edit a particular Author by AuthorId
        public IActionResult Edit(int id)
        {
            var particularAuthor = Author.GetThisAuthor(id);
            return View(particularAuthor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Author author)
        {
            Author.EditAuthor(id, author);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Console.WriteLine("Deleting.. from Controller");
            Author.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
