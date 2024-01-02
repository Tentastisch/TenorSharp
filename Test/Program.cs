using TenorSharp;
using TenorSharp.Parameters;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TenorClient tenorClient = new TenorClient("AIzaSyDvog0c38TnM345-ZmfDmrlJV1CJENFr0U");

            var searchParameter = new SearchParameter();
            searchParameter.query = "sousou no frieren";

            tenorClient.Search(searchParameter);
        }
    }
}