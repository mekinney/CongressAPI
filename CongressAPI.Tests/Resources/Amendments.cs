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
    public class Amendments : CongressAPITestBase
    {
        public Amendments()
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
        public void AmendmentResourceWillGetSomeAmendments()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetAmendmentsPageAsync().Result;
            Assert.IsNotNull(l, "Result is NULL.");
            Assert.IsTrue(l.Results.Count() > 0, "Query returned 0 results");
        }


        [TestMethod]
        public void AmendmentResourceWillReturnResultsFromAllFields()
        {
            var fieldList = GetAllFieldNames<Amendment>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetAmendmentsPageAsync(fieldList, sortList, filterList, 0, 5).Result;

            // Check there are some results.
            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");

            // Spot check some required fields.
            Assert.IsNotNull(data.Results[0].amendment_id, "Field amendment_id is NULL.");
            Assert.IsNotNull(data.Results[0].number, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Field chamber is NULL.");
            Assert.IsNotNull(data.Results[0].amendment_type, "Field amendment_type is NULL.");

        }


        [TestMethod]
        public void AmendmentResourceWillReturnNothing()
        {
            var fieldList = GetAllFieldNames<Amendment>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { new FilterSpec("chamber", new List<string> { "invalidchamber" }) };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetAmendmentsPageAsync(fieldList, sortList, filterList, 0, 5).Result;

            // Check there are some results.
            Assert.IsFalse(data.Results.Count() > 0, "Query returned more than 0 results");

        }

    }
}
