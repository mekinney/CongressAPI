using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI
{
    class CongressAPIApiException : Exception
    {
        public int StatusCode { get; private set; }

        public CongressAPIApiException(int statusCode, string error)
            : base("CongressAPI API Error: " + statusCode + ": " + error)
        {
            StatusCode = statusCode;
        }
    }
}
