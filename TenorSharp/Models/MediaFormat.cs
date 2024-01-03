using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Models
{
    /// <summary>
    /// Media format that contains more in depth information 
    /// </summary>
    public class MediaFormat
    {
        /// <summary>
        /// A URL to the media source.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Represents the time in seconds for one loop of the content. If the content is static, the duration is set to 0.
        /// </summary>
        public double duration { get; set; }

        /// <summary>
        /// Width and height of the media in pixels.
        /// </summary>
        public int[] dims { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public int size { get; set; }
    }
}
