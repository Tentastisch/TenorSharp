using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Filter
{
    public class SearchFilter
    {
        private bool sticker = false;
        private bool stat = false;
        private bool minStat = false;

        private SearchFilter(bool sticker, bool stat, bool minStat)
        {
            this.sticker = sticker;
            this.stat = stat;
            this.minStat = minStat;
        }

        public SearchFilter Sticker()
        {
            return new SearchFilter(true, false, false);
        }

        public SearchFilter OnlyAnimated()
        {
            return new SearchFilter(true, false, true);
        }

        public SearchFilter OnlyStatic()
        {
            return new SearchFilter(true, true, false);
        }

        public string ToString()
        {
            StringBuilder builder = new StringBuilder("");
            
            if (sticker)
                builder.Append("sticker");

            if (stat)
                builder.Append(",static");

            if (minStat)
                builder.Append(",-static");

            return builder.ToString();
        }
    }
}
