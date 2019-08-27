using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;

namespace LibraryMvc.Controllers
{
    public class CopiesController : Controller
    {

        // Display all Copies
        public IActionResult Index()
        {
            var allCopy = Copy.GetAllCopies();
            return View(allCopy);
        }

        // Create new Copy
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

        // Edit a particular Copy by CopyId
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


        // View details of a particular Copy by CopyId
        public IActionResult Details(int id)
        {
            var thisCopy = Copy.GetThisCopy(id);
            return View(thisCopy);
        }

        // Delete particular Copy by CopyId
        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Copy.DeleteCopy(id);
            return RedirectToAction("Index");
        }
        
    }
}
