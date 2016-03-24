using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using CongressAPI;
using CongressAPI.Model;

namespace CongressAPI.Tests
{
    /// <summary>
    /// Summary description for Bills
    /// </summary>
    [TestClass]
    public class Bills : CongressAPITestBase
    {
        public Bills()
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
        public void billResourceWillReturnGetAllCurrentBills()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetBillsPageAsync().Result;
            Assert.IsNotNull(l, "Result is NULL.");
            Assert.IsTrue(l.Results.Count() > 0, "Query returned 0 results");
        }

        [TestMethod]
        public void billResourceWillReturnResultsFromAllFields()
        {
            var fieldList = GetAllFieldNames<Bill>();
            Debug.WriteLine("fieldList.count = {0}", fieldList.Count);
            var sortList = new List<SortSpec> { };
            var filterList = new List<FilterSpec> { };

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var data = CongressAPI.GetBillsPageAsync(fieldList, sortList, filterList, 0, 5).Result;

            foreach (Bill bill in data.Results)
            {
                Debug.WriteLine("bill id, introduced_on, last_vote_at: {0}, {1}, {2}",bill.bill_id,bill.introduced_on,bill.last_vote_at);
            }

            Assert.IsNotNull(data, "Result is NULL.");
            Assert.IsTrue(data.Results.Count() > 0, "Query returned 0 results");
            Assert.IsNotNull(data.Results[0].bill_id, "Bill field bill_id is NULL.");
            Assert.IsNotNull(data.Results[0].bill_type, "Bill field bill_type is NULL.");
            Assert.IsNotNull(data.Results[0].number, "Bill field number is NULL.");
            Assert.IsNotNull(data.Results[0].congress, "Bill field congress is NULL.");
            Assert.IsNotNull(data.Results[0].chamber, "Bill field chamber is NULL.");

        }
    }
}