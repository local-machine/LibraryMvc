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
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorBook> Books { get; }

        public Author()
        {
            this.Books = new HashSet<AuthorBook>();
        }

        // Display All Authors
        public static List<Author> GetAllAuthors()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("authors", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var allAuthors = JsonConvert.DeserializeObject<List<Author>>(jsonResponse.ToString());
            return allAuthors;
        }

        // Display particular Author by AuthorId
        public static Author GetThisAuthor(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("authors/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content); //Our page returns an OBJECT in our JSON, instead of an array of objects (like when we do GetAll()). Therefore, we must deserialize the Json information as a JObject
            var thisAuthor = JsonConvert.DeserializeObject<Author>(jsonResponse.ToString());
            return thisAuthor;
        }

        // Create new Author
        public static void CreateAuthor(Author author)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("authors", Method.POST);
            request.AddJsonBody(author);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Delete particular Author by AuthorId
        public static void DeleteAuthor(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("authors" + id, Method.DELETE);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Edit a particular Author by AuthorId
        public static void EditAuthor(int id, Author author)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("authors" + id, Method.PUT);
            request.AddJsonBody(author);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }
    }

}
