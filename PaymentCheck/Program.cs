﻿using PaymentCheck;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using PaymentCheckService;

namespace PaymentCheckService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            
            //string endpoint = "https://jsonplaceholder.typicode.com/todos/1";
            string endpoint = "https://api.stripe.com/v1/customers";

            RestClient rClient = new RestClient();
            rClient.endpoint = endpoint;
            string response = rClient.makeRequest();
            //string response = "[" + rClient.makeRequest() + "]";
            System.Diagnostics.Debug.WriteLine(response);
            System.Diagnostics.Debug.WriteLine("TESTTESTTEST");

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //List<Todo> todos =  (List<Todo>)javaScriptSerializer.Deserialize(response, typeof(List<Todo>));
            //System.Diagnostics.Debug.WriteLine("TESTTESTTEST");
            //System.Diagnostics.Debug.WriteLine("COUNT: " + todos.Count);

            ////System.Diagnostics.Debug.WriteLine(todos[0].title);


            //foreach (Todo todo in todos)
            //{
            //    System.Diagnostics.Debug.WriteLine(todo.title);
            //    System.Diagnostics.Debug.WriteLine(todo.title);
            //    System.Diagnostics.Debug.WriteLine(todo.title);

            //}

            var customers = Customers.FromJson(response);

            System.Diagnostics.Debug.WriteLine(customers.Data.Count);

            //populate fake delinquints
            int count = 0;
            foreach (CustomersDatum customer in customers.Data)
            {
                if (count%5==0) {
                    System.Diagnostics.Debug.WriteLine(count);

                    customer.Delinquent = true;
                }
                count++;


            }

            //create delinquent list
            List<CustomersDatum> delinquents = new List<CustomersDatum>();
            foreach (CustomersDatum customer in customers.Data)
            {
                if (customer.Delinquent == true)
                {
                    delinquents.Add(customer);
                    System.Diagnostics.Debug.WriteLine(delinquents.Count);

                }
            }
            System.Diagnostics.Debug.WriteLine(delinquents.Count);




        }

    }
}
