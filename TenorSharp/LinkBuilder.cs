using System.Collections.Specialized;

namespace TenorSharp
{
    /// <summary>
    /// Builds a new link to Tenor API
    /// </summary>
    internal class LinkBuilder
    {
        private const string _apiBase = "https://tenor.googleapis.com/v2/";

        private UriBuilder _builder;
        private NameValueCollection _parameters;

        /// <summary>
        /// Setup a new UriBuilder and parameter list for the link creation
        /// </summary>
        /// <param name="mode">API route which will be used</param>
        /// /// <param name="apiKey">API Key of the client</param>
        public LinkBuilder(ApiModes mode, string apiKey)
        {
            _builder = new UriBuilder(_apiBase + Enum.GetName(typeof(ApiModes), mode));
        }

        /// <summary>
        /// Adds parameters to the api link
        /// </summary>
        /// <param name="parameters">Parameters to add</param>
        public void AddParameters(NameValueCollection parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// Builds the finished api url
        /// </summary>
        /// <returns>Tenor API url</returns>
        public string Build()
        {
            _builder.Query = _parameters.ToString();
            Uri tenorUrl = _builder.Uri;

            return tenorUrl.ToString();
        }
    }

    public enum ApiModes
    {
        search,
        trending,
        categories,
        search_suggestions,
        autocomplete,
        trending_terms,
        registershare,
        gifs,
        random,
        anonid,

    }
}
