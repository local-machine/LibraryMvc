using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            var allAuthors = Author.GetAllAuthors();
            return View(allAuthors);
        }

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


        public ActionResult Edit()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Edit(int id)
        {
            
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisAuthor = Author.GetThisAuthor(id);
            return View(thisAuthor);
        }
    }
}
