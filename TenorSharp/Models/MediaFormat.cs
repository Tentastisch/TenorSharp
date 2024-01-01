using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Models
{
    public class MediaFormat
    {
        public string url { get; set; }
        public double duration { get; set; }
        public string preview { get; set; }
        public int[] dims { get; set; }
        public int size { get; set; }
    }
}
