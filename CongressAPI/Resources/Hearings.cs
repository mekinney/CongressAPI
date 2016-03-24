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

        private const string HearingsResourceString = "hearings";

        public CongressAPIResult<Hearing> GetHearingsPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return GetHearingsPageAsync(fieldList, sortList, filterList, pageNum, perPage).Result;
        }

        public async Task<CongressAPIResult<Hearing>> GetHearingsPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return await GetResourcePageAsync<Hearing>(HearingsResourceString, fieldList, sortList, filterList, pageNum, perPage);
        }

    }

}