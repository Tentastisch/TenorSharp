using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Models
{
    internal class HttpError
    {
        public error error { get; set; }
    }

    internal class error
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
