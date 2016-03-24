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

        private const string AmmendmentsResourceString = "amendments";

        public CongressAPIResult<Amendment> GetAmmendmentsPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return GetAmendmentsPageAsync(fieldList, sortList, filterList, pageNum, perPage).Result;
        }

        public async Task<CongressAPIResult<Amendment>> GetAmendmentsPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return await GetResourcePageAsync<Amendment>(AmmendmentsResourceString, fieldList, sortList, filterList, pageNum, perPage);
        }
    
    }

}
