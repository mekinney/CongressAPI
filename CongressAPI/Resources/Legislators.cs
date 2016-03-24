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
        private const string LegislatorsResourceString = "legislators";

        public CongressAPIResult<Legislator> GetLegislatorsPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = GetLegislatorsPageAsync(fieldList, sortList, filterList, pageNum, perPage);
            return r.Result;  // Async method returns a <Task>, we're not using await, so return the Result portion.
        }

        public async Task<CongressAPIResult<Legislator>> GetLegislatorsPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = await GetResourcePageAsync<Legislator>(LegislatorsResourceString, fieldList, sortList, filterList, pageNum, perPage);
            return r;                
        }

        public async Task<CongressAPIResult<Legislator>> GetAllCurrentLegislatorsAsync(List<string> fieldList = null, 
            List<SortSpec> sortList = null, List<FilterSpec> filterList = null)
        {
            string query = LegislatorsResourceString + "?per_page=all";

            var r = await GetResourcePageAsync<Legislator>(query, fieldList, sortList, filterList, null, null);
            return r;
        }

    }

}
