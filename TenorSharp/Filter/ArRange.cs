namespace TenorSharp.Filter
{
    /// <summary>
    /// Range of the aspect ratio to include.
    /// </summary>
    public enum ArRange
    {
        /// <summary>
        /// No constraints
        /// </summary>
        all,

        /// <summary>
        /// 0.42 <= aspect ratio <= 2.36
        /// </summary>
        wide,

        /// <summary>
        /// 0.56 <= aspect ratio <= 1.78
        /// </summary>
        standard
    }
}
