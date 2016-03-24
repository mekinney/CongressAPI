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

        // Define the API string specific to this resource request.
        private const string DistrictsResourceString = "districts/locate";

        public CongressAPIResult<District> GetDistrictsByZip(string zipCode)
        {
            return GetDistrictsPageAsync("?zip=" + zipCode).Result;
        }

        public CongressAPIResult<District> GetDistrictsByLatLong(double latitude, double longitude)
        {
            string query = String.Format("?latitude={0}&longitude={1}", latitude, longitude);
            return GetDistrictsPageAsync(query).Result;
        }

        // The above two API calls are the only versions publically available.

        private async Task<CongressAPIResult<District>> GetDistrictsPageAsync(string customResource)
        {
            return await GetResourcePageAsync<District>(DistrictsResourceString + customResource);
        }

    }

}
