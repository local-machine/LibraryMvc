using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<AuthorBook> Authors { get; set; }

        public Book()
        {
            this.Authors = new HashSet<AuthorBook>();
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

        public static void CreateBook(Book book)
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
