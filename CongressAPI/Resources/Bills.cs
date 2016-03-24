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
        private const string BillsResourceString = "bills";

        public CongressAPIResult<Bill> GetBillsPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = GetBillsPageAsync(fieldList, sortList, filterList, pageNum, perPage);
            return r.Result;
        }

        public async Task<CongressAPIResult<Bill>> GetBillsPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            var r = await GetResourcePageAsync<Bill>(BillsResourceString, fieldList, sortList, filterList, pageNum, perPage);
            return r;
        }

    }

}