using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;


namespace SoftClient
{
    class Program
    {
        const string url = "http://localhost:8000";

        static void Main(string[] args)
        {
            Console.WriteLine($"registering this client to server: {url}");


            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url))
            {
                var response = DoRun();
                Console.WriteLine($"registation status: {response.Status}");
                Console.WriteLine("Waiting for server to send commands");
                Console.WriteLine("Press <ENTER> twice to terminate this client");

                Console.ReadLine();
                Console.ReadLine();
            }
        }

        static async Task<string> DoRun()
        { 


                WebApp.RestClient restclient = new WebApp.RestClient("http://localhost:9000");

                // object initializer syntax
                string response = await restclient.Post< string, RequestViewModel > (
                            "api/registerclient/Register", new RequestViewModel() { url = url } 
                    );

                return response;
        }
    }

    public class RequestViewModel
    {
        public string url { get; set; }
    }


}



