using System.Collections.Specialized;
using System.Web;
using TenorSharp.Filter;

namespace TenorSharp.Parameters
{
    public class SearchParameter
    {
        public string? query { get; set; }
        public SearchFilter? searchFilter { get; set; }
        public string? country { get; set; }
        public string? locale { get; set; }
        public ContentFilter contentFilter = ContentFilter.off;
        public string? mediaFilter { get; set; }
        public ArRange arRange = ArRange.all;
        
        public int limit = 20;
        public string? pos { get; set; }

        public NameValueCollection Build(string apiKey)
        {
            NameValueCollection parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["key"] = apiKey;

            if (limit > 50 || limit < 0)
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

            return parameters;
        }
    }
}
