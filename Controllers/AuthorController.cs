using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

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

        [HttpPut]
        public IActionResult Edit(int id, Author author)
        {
            Author.EditAuthor(id, author);
            return RedirectToAction("Index");
        }
        
        // Delete particular Author by AuthorId
        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
