using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class CopiesController : Controller
    {
        public IActionResult Index()
        {
            var allCopy = Copy.GetAllCopies();
            return View(allCopy);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Copy copy)
        {
            Copy.CreateCopy(copy);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var thisCopy = Copy.GetThisCopy(id);
            return View(thisCopy);
        }

        [HttpPut]
        public IActionResult Edit(Copy copy, int id)
        {
            Copy.EditCopy(copy, id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisCopy = Copy.GetThisCopy(id);
            return View(thisCopy);
        }
    }
}
