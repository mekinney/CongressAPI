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
    public class Hearings : CongressAPITestBase
    {
        public Hearings()
        {

        }

        [TestMethod]
        public void HearingResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = GetAllFieldNames<Hearing>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { new SortSpec("occurs_at", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
                                                                                                      //            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetHearingsPageAsync(fieldList, sortList, null, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            Assert.IsTrue(data.Results[0].occurs_at > data.Results[1].occurs_at,
                            String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].occurs_at, data.Results[1].occurs_at));
            Assert.IsNotNull(data.Results[0].committee_id, "Field committee_id is NULL.");
            Assert.IsNotNull(data.Results[0].congress, "Field congress is NULL.");
            Assert.IsNotNull(data.Results[0].occurs_at, "Field occurs_at is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].dc, "Field dc is NULL.");
            Assert.IsNotNull(data.Results[0].bill_ids, "Field bill_ids is NULL.");
        }

        [TestMethod]
        public void HearingResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Hearing>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("committee_id", new List<string> { "invalid" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetHearingsPageAsync(fieldList, sortList, filterList, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }



    }
}
