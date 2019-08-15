using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaymentCheckService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
            //string endpoint = "https://jsonplaceholder.typicode.com/todos/1";
            string endpoint = "https://api.stripe.com/v1/customers?limit=3";

            //var builder = new UriBuilder("https://api.stripe.com/v1/customers?");
            //var query = HttpUtility.ParseQueryString(builder.Query);
            //query["apiKey"] = "12345";
            //builder.Query = query.ToString();
            //client.BaseAddress = new Uri(builder.ToString());

            RestClient rClient = new RestClient();
            rClient.endpoint = endpoint;
            string response = rClient.makeRequest();
            System.Diagnostics.Debug.WriteLine(response);


        }

    }
}
