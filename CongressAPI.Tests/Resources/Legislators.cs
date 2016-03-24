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
    public class Legislators : CongressAPITestBase
    {
        public Legislators()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void legislatorResourceWillReturnGetAllCurrentLegislators()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetAllCurrentLegislatorsAsync().Result;
            Assert.IsNotNull(l, "Result is NULL.");
            Assert.IsTrue(l.Results.Count() > 0, "Query returned 0 results");
        }

        [TestMethod]
        public void legislatorResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = new List<string> { "ocd_id", "bioguide_id", "thomas_id", "lis_id", "govtrack_id", "votesmart_id","crp_id","icpsr_id", "fed_ids","state" };
            var sortList = new List<SortSpec> { new SortSpec("bioguide_id", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetLegislatorsPageAsync(fieldList, sortList, filterList, 0, 5).Result;
            Debug.WriteLine("Bioguide IDs.  id[0]={0} should be greater than id[1]={1}", data.Results[0].bioguide_id, data.Results[1].bioguide_id);

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");
            Assert.IsTrue(data.Results[0].state == "AZ", "Result returned the wrong state. state should be AZ and is = "+data.Results[0].state);
            Assert.IsTrue((String.CompareOrdinal(data.Results[0].bioguide_id, data.Results[1].bioguide_id) > 0), 
                            String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].bioguide_id, data.Results[1].bioguide_id));
        }

        [TestMethod]
        public void legislatorResourceWillReturnResultsFromAllFields()
        {
            var fieldList = GetAllFieldNames<Legislator>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetLegislatorsPageAsync(fieldList, sortList, filterList, 0, 5).Result;

            // Check there are some results.
            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            // Spot check some required fields.
            Assert.IsNotNull(data.Results[0].in_office, "Field in_office is NULL.");
            Assert.IsNotNull(data.Results[0].party, "Field party is NULL.");
            Assert.IsNotNull(data.Results[0].gender, "Field gender is NULL.");
            Assert.IsNotNull(data.Results[0].state, "Field state is NULL.");
            Assert.IsNotNull(data.Results[0].state_name, "Field state_name is NULL.");
            Assert.IsNotNull(data.Results[0].title, "Field title is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].state, "Field state is NULL.");
            Assert.IsNotNull(data.Results[0].bioguide_id, "Field bioguide_id is NULL.");
            Assert.IsNotNull(data.Results[0].ocd_id, "Field ocd_id is NULL.");

        }

    }
}
