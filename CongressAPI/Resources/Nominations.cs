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
        private const string NominationsResourceString = "nominations";

        public CongressAPIResult<Nomination> GetNominationsPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return GetNominationsPageAsync(fieldList, sortList, filterList, pageNum, perPage).Result;
        }

        public async Task<CongressAPIResult<Nomination>> GetNominationsPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return await GetResourcePageAsync<Nomination>(NominationsResourceString, fieldList, sortList, filterList, pageNum, perPage);
        }

    }

}
