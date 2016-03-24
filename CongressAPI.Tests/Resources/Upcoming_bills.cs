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
    public class Upcoming_bills : CongressAPITestBase
    {
        public Upcoming_bills()
        {

        }

        [TestMethod]
        public void Upcoming_billResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = GetAllFieldNames<Upcoming_bill>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { new SortSpec("scheduled_at", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
                                                                                                      //            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetUpcoming_billsPageAsync(fieldList, sortList, null, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            //Need reliable way to test sorting.
            //Assert.IsTrue((String.CompareOrdinal(data.Results[0].scheduled_at, data.Results[1].scheduled_at) > 0),
            //                String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].scheduled_at, data.Results[1].scheduled_at));

            Assert.IsNotNull(data.Results[0].scheduled_at, "Field scheduled_at is NULL.");
            Assert.IsNotNull(data.Results[0].congress, "Field congress is NULL.");
            Assert.IsNotNull(data.Results[0].legislative_day, "Field legislative_day is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].source_type, "Field source_type is NULL.");
        }

        [TestMethod]
        public void Upcoming_billResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Upcoming_bill>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("roll_id", new List<string> { "invalid" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetUpcoming_billsPageAsync(fieldList, sortList, filterList, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }



    }
}
