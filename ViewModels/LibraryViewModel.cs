using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewModel
{
    public class LibraryViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public IFormFile Photo {get;set;}

        public virtual ICollection<AuthorBook> Authors { get; set; }

        public LibraryViewModel()
        {
            this.Authors = new HashSet<AuthorBook>();
        }

        // Display all Books
        public static List<LibraryViewModel> GetAllBooks()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var allBooks = JsonConvert.DeserializeObject<List<LibraryViewModel>>(jsonResponse.ToString());
            return allBooks;
        }

        // Display particular Book by BookId
        public static LibraryViewModel GetThisBook(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisBook = JsonConvert.DeserializeObject<LibraryViewModel>(jsonResponse.ToString());
            return thisBook;
        }

        // Create new Book

        public static void CreateBook([FromBody] LibraryViewModel book)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("books/", Method.POST);
            request.AddJsonBody(book);
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
        public static void EditBook(int id, LibraryViewModel book)
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
