using TenorSharp.Parameters;
using Microsoft.Extensions.Logging;
using TenorSharp.Models;
using System.Text.Json;

namespace TenorSharp
{
    public class TenorClient
    {
        private string _key;
        private string? _clientKey;

        public ILogger logger;

        public TenorClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            this._key = apiKey;
        }

        public TenorClient(string apiKey, string clientKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            if (string.IsNullOrEmpty(clientKey))
                throw new ArgumentNullException(nameof(clientKey));

            this._key = apiKey;
            this._clientKey = clientKey;
        }
        public int Ping()
        {
            var apiUrl = new LinkBuilder(ApiModes.autocomplete, _key);


            return 0;
        }

        public SearchResults Search(string query, int amount = 20)
        {
            var searchParameter = new SearchParameter();
            searchParameter.query = query;
            searchParameter.limit = amount;

            return Search(searchParameter);
        }

        public SearchResults Search(SearchParameter searchParameter)
        {
            var linkBuilder = new LinkBuilder(ApiModes.search, _key);
            linkBuilder.AddParameters(searchParameter.Build(_key));
            var apiUrl = linkBuilder.Build();

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var respondJson = response.Content.ReadAsStringAsync().Result;
                    var searchResult = JsonSerializer.Deserialize<SearchResults>(respondJson);

                    return searchResult;
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync().Result;
                    HttpError error = JsonSerializer.Deserialize<HttpError>(errorContent);
                    logger.LogError("Error {Code} - {Message}", error.error.code, error.error.message);
                }
            }

            return null;
        }

        public async Task<SearchResults> SearchAsync(string query, int amount = 20)
        {
            var searchParameter = new SearchParameter();
            searchParameter.query = query;
            searchParameter.limit = amount;

            return await SearchAsync(searchParameter);
        }

        public async Task<SearchResults> SearchAsync(SearchParameter searchParameter)
        {
            var linkBuilder = new LinkBuilder(ApiModes.search, _key);
            linkBuilder.AddParameters(searchParameter.Build(_key));
            var apiUrl = linkBuilder.Build();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var respondJson = await response.Content.ReadAsStringAsync();
                    var searchResult = JsonSerializer.Deserialize<SearchResults>(respondJson);

                    return searchResult;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    HttpError error = JsonSerializer.Deserialize<HttpError>(errorContent);
                    logger.LogError("Error {Code} - {Message}", error.error.code, error.error.message);
                }
            }

            return null;
        }
    }
}
