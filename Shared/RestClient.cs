using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

/*
To post use something like this:

await RestClient.Post<Setting>($"/api/values/{id}", setting);
Example for delete:

await RestClient.Delete($"/api/values/{id}");
Example to get list:

List<ClaimTerm> claimTerms = await RestClient.Get<List<ClaimTerm>>("/api/values/");
Example to get only one:

ClaimTerm processedClaimImage = await RestClient.Get<ClaimTerm>($"/api/values/{id}"); 
 */
namespace WebApp
{
    public class RestClient
    {
        // In my case this is http://localhost:9000/
        private string _apiBasicUri = "";

        public RestClient(string url) { _apiBasicUri = url; }

        public async Task<R> Post<R, T>(string url, T contentValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                result.EnsureSuccessStatusCode();
                // If the response contains content we want to read it!
                string resultContentString = "";
                if (result.Content != null)
                    resultContentString = await result.Content.ReadAsStringAsync();

                R resultContent = JsonConvert.DeserializeObject<R>(resultContentString);
                return resultContent;
            }
        }

        public async Task<R> Put<R, T>(string url, T stringValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiBasicUri);
                var content = new StringContent(JsonConvert.SerializeObject(stringValue), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(url, content);
                result.EnsureSuccessStatusCode();
                // If the response contains content we want to read it!
                string resultContentString = "";
                if (result.Content != null)
                    resultContentString = await result.Content.ReadAsStringAsync();

                R resultContent = JsonConvert.DeserializeObject<R>(resultContentString);
                return resultContent;
            }
        }

        public async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiBasicUri);
                var result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public async Task<R> Delete<R>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiBasicUri);
                var result = await client.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                // If the response contains content we want to read it!
                string resultContentString = "";
                if (result.Content != null)
                    resultContentString = await result.Content.ReadAsStringAsync();

                R resultContent = JsonConvert.DeserializeObject<R>(resultContentString);
                return resultContent;
            }
        }
    }
}



