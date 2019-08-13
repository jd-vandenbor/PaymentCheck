using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentCheckService
{
    public class Program
    {
        public static void Main(string[] args)
        {


            string endpoint = "https://jsonplaceholder.typicode.com/todos/1";
            RestClient rClient = new RestClient();
            rClient.endpoint = endpoint;
            string response = rClient.makeRequest();
            System.Diagnostics.Debug.WriteLine(response);


        }

    }
}
