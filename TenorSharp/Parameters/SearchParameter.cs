using System.Collections.Specialized;
using System.Web;
using TenorSharp.Filter;

namespace TenorSharp.Parameters
{
    public class SearchParameter
    {
        public string? query { get; set; }
        public string? locale { get; set; }
        public MediaFilter mediaFilter = MediaFilter.basic;
        public ArRange arRange = ArRange.all;
        public ContentFilter contentFilter = ContentFilter.off;
        public int limit = 20;
        public string? pos { get; set; }
        public string? anonId { get; set; }

        public NameValueCollection Build(string apiKey)
        {
            NameValueCollection parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["key"] = apiKey;

            if (limit > 50)
                throw new Exception("Limit can not be over 50.");

            if (!string.IsNullOrEmpty(query)) parameters["q"] = query;
            if (!string.IsNullOrEmpty(locale)) parameters["locale"] = locale;

            parameters["media_filter"] = Enum.GetName(typeof(MediaFilter), mediaFilter);
            parameters["ar_range"] = Enum.GetName(typeof(ArRange), arRange);
            parameters["contentfilter"] = Enum.GetName(typeof(ContentFilter), contentFilter);
            parameters["limit"] = limit.ToString();

            if (!string.IsNullOrEmpty(pos)) parameters["pos"] = pos;
            if (!string.IsNullOrEmpty(anonId)) parameters["anon_id"] = anonId;

            return parameters;
        }
    }
}
