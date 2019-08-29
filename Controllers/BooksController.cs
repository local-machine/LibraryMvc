using Microsoft.AspNetCore.Mvc;
using LibraryMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.ViewModel;
using System.Threading.Tasks;

namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
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
        public IActionResult Create(Book model)
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(model.Image);
            Console.WriteLine("---------------------------------------------------------------------");
            LibraryViewModel lib = new LibraryViewModel();
            if(ModelState.IsValid)
            {              
                string uniqueFileName = null;
                 Console.WriteLine("VImage testing for valid");
                if (model.Image != null)
                {
                    Console.WriteLine("Hello!!!!!!!");
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    Console.WriteLine(uploadsFolder);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + lib.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Console.WriteLine(filePath);
                    lib.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Book newBook = new Book 
                {
                    Title= model.Title,
                    Genre= model.Genre, 
                    Image = uniqueFileName
                };
            }
           
           Book.CreateBook(model);
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
