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
        static string listen = ""; // example: "http://localhost:8000";
        static string server = ""; // example: "http://localhost:9000"

        static int Main(string[] args)
        {
            if (args.Length != 4 || args[0] != "-listen" || args[2] != "-connect") { 
                Console.WriteLine($"Usage: SoftClient -listen url -connect server");
                Console.WriteLine($"   e.g: SoftClient -listen http://localhost:8000 -connect http://localhost:9000");
                return 1;
            }


            listen = args[1];
            server = args[3];
            Console.WriteLine($"this client is listening at: {listen}");


            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(listen))
            {
                var response = DoRun();
                Console.WriteLine($"registation status: {response.Status}");
                Console.WriteLine("Waiting for server to send commands");
                Console.WriteLine("Press <ENTER> twice to terminate this client");

                Console.ReadLine();
                Console.ReadLine();
            }

            return 0;
        }

        static async Task<string> DoRun()
        {

            Console.WriteLine($"connecting to server: {server}");
            WebApp.RestClient restclient = new WebApp.RestClient(server);

            Console.WriteLine($"registering this client to server: {server}");
            // object initializer syntax
            string response = await restclient.Post< string, RequestViewModel > (
                            "api/registerclient/Register", new RequestViewModel() { url = listen } 
                    );

                return response;
        }
    }

    public class RequestViewModel
    {
        public string url { get; set; }
    }


}



