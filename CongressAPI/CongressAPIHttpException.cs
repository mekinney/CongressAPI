using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI
{
    public class CongressAPIHttpException : Exception
    {
        public CongressAPIHttpException(string content)
            : base("CongressAPI HTTP Exception (bad API request): " + content)
        {

        }

        public CongressAPIHttpException(string content, Exception innerEx)
            : base("CongressAPI HTTP Exception (bad API request): " + content, innerEx)
        {

        }
    }
}
