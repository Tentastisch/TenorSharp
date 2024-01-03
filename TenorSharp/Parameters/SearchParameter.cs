using System.Collections.Specialized;
using System.Web;
using TenorSharp.Filter;

namespace TenorSharp.Parameters
{
    /// <summary>
    /// More in depth parameters for Tenor search.
    /// </summary>
    public class SearchParameter
    {
        /// <summary>
        /// Query for the Tenor search.
        /// </summary>
        public string? query { get; set; }

        /// <summary>
        /// Search filter for non-GIF sticker content.
        /// </summary>
        public SearchFilter? searchFilter { get; set; }

        /// <summary>
        /// Specify the country of origin for the request. To do so, provide its two-letter ISO 3166-1 country code.
        /// Example: US
        /// </summary>
        public string? country { get; set; }

        /// <summary>
        /// Specify the default language to interpret the search string (xx_YY). 
        /// xx is the language's ISO 639-1 language code, while the optional _YY value is the two-letter ISO 3166-1 country code.
        /// Example: en_US
        /// </summary>
        public string? locale { get; set; }

        /// <summary>
        /// The content safety filter.
        /// </summary>
        public ContentFilter contentFilter = ContentFilter.off;

        /// <summary>
        /// Comma-separated list of GIF formats to filter.
        /// Example: gif,tinygif,mp4,tinymp4
        /// </summary>
        public string? mediaFilter { get; set; }

        /// <summary>
        /// Filter the aspect ratio range to include only GIFs with certein aspect ratios.
        /// </summary>
        public ArRange arRange = ArRange.all;

        /// <summary>
        /// Whether to randomly order the response.
        /// </summary>
        public bool random = false;

        /// <summary>
        /// Fetch up to the specified number of results. Has to be between 1 and 50.
        /// </summary>
        public int limit = 20;

        /// <summary>
        /// Receive results that start at the position. Next can be get by previous search results.
        /// </summary>
        public string? pos { get; set; }

        /// <summary>
        /// Internal class to build all parameters into one collection.
        /// </summary>
        /// <param name="apiKey">Current api key of the client. Has to be included.</param>
        /// <returns>New collection of api search parameters.</returns>
        /// <exception cref="Exception">If limit is not between 0 and 50.</exception>
        internal NameValueCollection Build(string apiKey)
        {
            NameValueCollection parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["key"] = apiKey;

            if (limit < 0 || limit > 50)
                throw new Exception("Limit has to be over 0 and under 50");

            if (!string.IsNullOrEmpty(query)) parameters["q"] = query;
            if (searchFilter != null) parameters["searchfilter"] = searchFilter.ToString();
            if (!string.IsNullOrEmpty(country)) parameters["country"] = country;
            if (!string.IsNullOrEmpty(locale)) parameters["locale"] = locale;
            if (!string.IsNullOrEmpty(mediaFilter)) parameters["media_filter"] = mediaFilter;
            if (!string.IsNullOrEmpty(pos)) parameters["pos"] = pos;
            parameters["contentfilter"] = Enum.GetName(typeof(ContentFilter), contentFilter);
            parameters["ar_range"] = Enum.GetName(typeof(ArRange), arRange);
            parameters["limit"] = limit.ToString();
            parameters["random"] = random.ToString();

            return parameters;
        }
    }
}
