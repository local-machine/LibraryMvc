using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibraryMvc.Models
{
    public class Copy
    {
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public ICollection<Book> Books { get; }

        public bool Available { get; set; }

        public Copy(bool Available)
        {
            Available = true;
        }


        public static List<Copy> GetAllCopies()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("copies", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var allCopies = JsonConvert.DeserializeObject<List<Copy>>(jsonResponse.ToString());
            return allCopies;
        }

        public static Copy GetThisCopy(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("copies/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisCopy = JsonConvert.DeserializeObject<Copy>(jsonResponse.ToString());
            return thisCopy;
        }

        public static void CreateCopy(Copy copy)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("copies", Method.POST);
                request.AddJsonBody(copy);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        public static void EditCopy(Copy copy, int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("copies/" + id, Method.PUT);
            request.AddJsonBody(copy);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await ApiCall.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }
    }
}
