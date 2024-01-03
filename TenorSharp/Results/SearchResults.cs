using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenorSharp.Models;

namespace TenorSharp.Results
{
    /// <summary>
    /// The response of the Tenor API. Contains an array of different results and a pointer to the next results.
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// Array of results
        /// </summary>
        public SearchResult[] results { get; set; }

        /// <summary>
        /// String with the pointer to the next results
        /// </summary>
        public string next { get; set; }
    }

    /// <summary>
    /// Result that contains all the information.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Tenor result identifier.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The title of the post.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// A list of media formats of the result
        /// </summary>
        public MediaFormats media_formats { get; set; }

        /// <summary>
        /// A Unix timestamp that represents when this post was created.
        /// </summary>
        public double created { get; set; }

        /// <summary>
        /// A textual description of the content.
        /// </summary>
        public string content_description { get; set; }

        /// <summary>
        /// The full URL to view the post on tenor.com
        /// </summary>
        public string itemurl { get; set; }

        /// <summary>
        /// A short URL to view the post on tenor.com
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// An array of tags for the post.
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// Comma-separated list to signify whether the content is a sticker or static image, has audio, or is any combination of these. 
        /// If sticker and static aren't present, then the content is a GIF. A blank flags field signifies a GIF without audio.
        /// </summary>
        public string[] flags { get; set; }

        /// <summary>
        /// Returns true if this post contains audio.
        /// </summary>
        public bool hasaudio { get; set; }
    }
}
