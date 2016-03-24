using System;
using System.Text;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using CongressAPI;
using CongressAPI.Model;

namespace CongressAPI.Tests
{
    [TestClass]
    public class Floor_updates : CongressAPITestBase
    {
        public Floor_updates()
        {

        }

        [TestMethod]
        public void Floor_updatesResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = GetAllFieldNames<Floor_update>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { new SortSpec("timestamp", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
                                                                                                      //            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetFloor_updatesPageAsync(fieldList, sortList, null, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            Assert.IsTrue((String.CompareOrdinal(data.Results[0].timestamp, data.Results[1].timestamp) > 0),
                            String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].timestamp, data.Results[1].timestamp));
            Assert.IsNotNull(data.Results[0].timestamp, "Field timestamp is NULL.");
            Assert.IsNotNull(data.Results[0].congress, "Field congress is NULL.");
            Assert.IsNotNull(data.Results[0].legislative_day, "Field legislative_day is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].year, "Field year is NULL.");
            Assert.IsNotNull(data.Results[0].bill_ids, "Field bill_idst is NULL.");
        }

        [TestMethod]
        public void Floor_updateResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Floor_update>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("timestamp", new List<string> { "invalid" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetFloor_updatesPageAsync(fieldList, sortList, filterList, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }



    }
}
