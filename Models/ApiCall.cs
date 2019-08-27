
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibraryMvc.Models
{
    public class ApiCall 
    {
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
            {
                var tcs = new TaskCompletionSource<IRestResponse>();
                theClient.ExecuteAsync(theRequest, response => {
                    tcs.SetResult(response);
                });
                return tcs.Task;
            }
    }
   
}