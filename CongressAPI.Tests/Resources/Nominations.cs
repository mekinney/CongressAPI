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
    public class Nominations : CongressAPITestBase
    {
        public Nominations()
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
        public void nominationResourceWillReturnFieldsFilteredandSorted()
        {
            var fieldList = GetAllFieldNames<Nomination>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { new SortSpec("nomination_id", SortDirection.desc) };        // Ascending order is the default, so use descending for the test.
//            var filterList = new List<FilterSpec> { new FilterSpec("state", new List<string> { "AZ" }) };
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetNominationsPageAsync(fieldList, sortList, null, 0, 5).Result;
            Debug.WriteLine("Data returned. Count = {0}", data.Results.Count);
            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");
            Assert.IsTrue((String.CompareOrdinal(data.Results[0].nomination_id, data.Results[1].nomination_id) > 0),
                            String.Format("Results not sorted correctly.  id[0]={0} should be greater than id[1]={1}", data.Results[0].nomination_id, data.Results[1].nomination_id));
            Assert.IsNotNull(data.Results[0].nomination_id, "Field nomination_id is NULL.");
            Assert.IsNotNull(data.Results[0].congress, "Field congress is NULL.");
            Assert.IsNotNull(data.Results[0].number, "Field number is NULL.");
            Assert.IsNotNull(data.Results[0].received_on, "Field state is NULL.");
            Assert.IsNotNull(data.Results[0].last_action_at, "Field last_action_at is NULL.");
            Assert.IsNotNull(data.Results[0].organization, "Field organization is NULL.");
        }

        [TestMethod]
        public void nominationResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Nomination>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("nomination_id", new List<string> { "invalidchamber" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetNominationsPageAsync(fieldList, sortList, filterList, 0, 5).Result;

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }



    }
}
