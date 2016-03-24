using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongressAPI.Model
{
    // This abstract class contains all the common wrapper information for a Congress API result.
    public abstract class CongressAPIBase
    {

        // TODO: Define constants for CongressAPI error results
        public const int StatusOk = 1;
        public const int StatusApiKeyInvalid = 100;
        public const int StatusObjectNotFound = 101;
        public const int StatusErrorUrlFormat = 102;
        public const int StatusFilterError = 104;
        public const int StatusRateLimitExceeded = 107;
        public const int DefaultPerPage = 20;

        // Store final query for diagnostics.
        public string finalQuery { get; set; }

        // Paging information can be returned for all queries
        public int count { get; set; }
        public Page page { get; set; }

    }

    public class Page
    {
        public int count { get; set; }
        public int? per_page { get; set; }
        public int? page { get; set; }
    }

    public class CongressAPIResult<TResult> : CongressAPIBase
    {
        public List<TResult> Results { get; set; }
    }

}
