using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
  }

}
