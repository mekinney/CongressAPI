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

        private const string Floor_updatesResourceString = "floor_updates";

        public CongressAPIResult<Floor_update> GetFloor_updatesPage(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return GetFloor_updatesPageAsync(fieldList, sortList, filterList, pageNum, perPage).Result;
        }

        public async Task<CongressAPIResult<Floor_update>> GetFloor_updatesPageAsync(List<string> fieldList = null, List<SortSpec> sortList = null,
                List<FilterSpec> filterList = null, int pageNum = 0, int perPage = CongressAPIBase.DefaultPerPage)
        {
            return await GetResourcePageAsync<Floor_update>(Floor_updatesResourceString, fieldList, sortList, filterList, pageNum, perPage);
        }

    }

}
