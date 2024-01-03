using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Models
{
    public class MediaFormats
    {
        public MediaFormat preview { get; set; }
        public MediaFormat gif { get; set; }
        public MediaFormat mediumgif { get; set; }
        public MediaFormat tinygif { get; set; }
        public MediaFormat nanogif { get; set; }
        public MediaFormat mp4 { get; set; }
        public MediaFormat loopedmp4 { get; set; }
        public MediaFormat tinymp4 { get; set; }
        public MediaFormat nanomp4 { get; set; }
        public MediaFormat webm { get; set; }
        public MediaFormat tinywebm { get; set; }
        public MediaFormat nanowebm { get; set; }
        public MediaFormat webp_transparent { get; set; }
        public MediaFormat tinywebp_transparent { get; set; }
        public MediaFormat nanowebp_transparent { get; set; }
        public MediaFormat gif_transparent { get; set; }
        public MediaFormat tinygif_transparent { get; set; }
        public MediaFormat nanogif_transparent { get; set; }
    }
}
