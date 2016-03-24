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

        private const string CommitteesResourceString = "committees";

        public CongressAPIResult<Committee> GetCommitteesPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return GetCommitteesPageAsync(fieldList, sortList, filterList, pageNum, perPage).Result;
        }

        public async Task<CongressAPIResult<Committee>> GetCommitteesPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return await GetResourcePageAsync<Committee>(CommitteesResourceString, fieldList, sortList, filterList, pageNum, perPage);
        }

    }

}
