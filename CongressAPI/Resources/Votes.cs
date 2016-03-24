using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongressAPI;
using CongressAPI.Model;

namespace CongressAPI
{
    public partial class CongressAPIRestClient
    {

        private const string VotesResourceString = "votes";

        public CongressAPIResult<Vote> GetVotesPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = GetVotesPageAsync(fieldList, sortList, filterList, pageNum, perPage);
            return r.Result;  // Async method returns a <Task>, we're not using await, so return the Result portion.
        }

        public async Task<CongressAPIResult<Vote>> GetVotesPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = await GetResourcePageAsync<Vote>(VotesResourceString, fieldList, sortList, filterList, pageNum, perPage);
            return r;
        }

    }

}
