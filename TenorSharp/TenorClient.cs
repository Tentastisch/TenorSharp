using Newtonsoft.Json;
using TenorSharp.Models;
using TenorSharp.Parameters;

namespace TenorSharp
{
    public class TenorClient
    {
        private string _key;
        private string? _clientKey;

        
        public TenorClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            this._key = apiKey;
        }

        public int Ping()
        {
            var apiUrl = new LinkBuilder(ApiModes.autocomplete, _key);


            return 0;
        }

        public void Search(SearchParameter searchParameter)
        {
            var linkBuilder = new LinkBuilder(ApiModes.search, _key);
            linkBuilder.AddParameters(searchParameter.Build(_key));
            var apiUrl = linkBuilder.Build();

            Console.WriteLine(apiUrl);

            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(apiUrl).Result;

                Console.WriteLine(json);

                //SearchResult results = JsonConvert.DeserializeObject<SearchResult>(json);
            }
        }

        public async Task SearchAsync(SearchParameter searchParameter)
        {

        }
    }
}
