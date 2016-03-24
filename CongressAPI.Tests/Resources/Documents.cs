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
    public class Documents : CongressAPITestBase
    {
        public Documents()
        {

        }

        [TestMethod]
        public void DocumentResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = GetAllFieldNames<Document>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { new SortSpec("published_on", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
                                                                                                      //            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetDocumentsPageAsync(fieldList, sortList, null, 0, 50).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            //Assert.IsTrue((String.CompareOrdinal(data.Results[0].roll_id, data.Results[1].roll_id) > 0),
            //                String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].roll_id, data.Results[1].roll_id));
            Assert.IsNotNull(data.Results[0].document_type, "Field document_type is NULL.");
        }

        [TestMethod]
        public void DocumentResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Document>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("roll_id", new List<string> { "invalid" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetDocumentsPageAsync(fieldList, sortList, filterList, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }



    }
}
