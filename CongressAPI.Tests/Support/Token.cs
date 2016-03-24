using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CongressAPI.Tests.Support
{
    public static class Token
    {
        /// <summary>
        /// Gets the API token for tests. Located in api_token.private folder in same folder.
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            return File.ReadAllText(@"..\..\Support\api_token.private");
        }
    }
}
