using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Library.ViewModel ;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace LibraryMvc.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Image {get;set;}

        public virtual ICollection<AuthorBook> Authors { get; set; }
        private readonly IHostingEnvironment hostingEnvironment;

        public Book()
        {
            this.Authors = new HashSet<AuthorBook>();
        }

          // Display first page of Books
        public static List<Book> GetBooks()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
            return bookList;
        }

        //  Display next page of Books
            public static List<Book> GetNextBooks()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/next", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
            return bookList;
        }

        //  Display prev page of Books
              public static List<Book> GetPrevDestinations()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/next", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var bookList = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
            return bookList;
        }

        // Display all Books
        public static List<Book> GetAllBooks()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var allBooks = JsonConvert.DeserializeObject<List<Book>>(jsonResponse.ToString());
            return allBooks;
        }

        // Display particular Book by BookId
        public static Book GetThisBook(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisBook = JsonConvert.DeserializeObject<Book>(jsonResponse.ToString());
            return thisBook;
        }

        // Create new Book

        public static void CreateBook(LibraryViewModel model )
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                Console.WriteLine("Valid");
                if (model.Photo != null)
                {
                    Console.WriteLine("Hello!!!!!!!");
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    Console.WriteLine(uploadsFolder);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Console.WriteLine(filePath);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Book newBook = new Book 
                {
                    Title= model.Title,
                    Genre= model.Genre,
                    Image = uniqueFileName
                };
                 
            }
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/", Method.POST);
            Console.WriteLine("Image of the book is " + model.Photo);
            request.AddJsonBody(model);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Delete particular Book by BookId
        public static void DeleteBook(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/" + id, Method.DELETE);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Edit a particular Book by BookId
        public static void EditBook(int id, Book book)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/" + id, Method.POST);
            request.AddJsonBody(book);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }
    }
}
