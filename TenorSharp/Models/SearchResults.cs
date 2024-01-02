using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Models
{
    public class SearchResults
    {
        public SearchResult[] results { get; set; }
    }

    public class SearchResult
    {
        public string id { get; set; }
        public string title { get; set; }
        public MediaFormats media_formats { get; set; }
        public double created { get; set; }
        public string content_description { get; set; }
        public string itemurl { get; set; }
        public string url { get; set; }
        public string[] tags { get; set; }
        public string[] flags { get; set; }
        public bool hasaudio { get; set; }
    }
}
