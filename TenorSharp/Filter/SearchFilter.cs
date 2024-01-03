using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenorSharp.Filter
{
    /// <summary>
    /// Filter to receive animated and static sticker. Do not use this on GIFs.
    /// </summary>
    public class SearchFilter
    {
        private bool sticker = false;
        private bool stat = false;
        private bool minStat = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sticker"></param>
        /// <param name="stat"></param>
        /// <param name="minStat"></param>
        private SearchFilter(bool sticker, bool stat, bool minStat)
        {
            this.sticker = sticker;
            this.stat = stat;
            this.minStat = minStat;
        }

        /// <summary>
        /// Creates a filter to receive static and animated sticker content.
        /// </summary>
        /// <returns>Filter for static and animated sticker</returns>
        public SearchFilter Sticker()
        {
            return new SearchFilter(true, false, false);
        }

        /// <summary>
        /// Creates a filter to receive animated sticker content only
        /// </summary>
        /// <returns>Filter for animated sticker</returns>
        public SearchFilter OnlyAnimated()
        {
            return new SearchFilter(true, false, true);
        }

        /// <summary>
        /// Creates a filter to receive static sticker content only.
        /// </summary>
        /// <returns>Filter for static sticker</returns>
        public SearchFilter OnlyStatic()
        {
            return new SearchFilter(true, true, false);
        }

        /// <summary>
        /// Internal method to make filter into a string.
        /// </summary>
        /// <returns></returns>
        internal string ToString()
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
