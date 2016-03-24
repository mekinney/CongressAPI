using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CongressAPI;
using CongressAPI.Model;
using CongressAPI.Tests.Support;
using System.Reflection;


namespace CongressAPI.Tests
{

    [TestClass]
    public class CongressAPITestBase
    {
        public string APIKey { get; set; }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {

            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // Used to create a field list that contains all of the top level properties of
        // a specific resource type.
        public List<string> GetAllFieldNames<T>() where T : new()
        {

            var obj = new T { };

            Type t = obj.GetType();
            var fieldList = new List<string> { };

            PropertyInfo[] propinfo = t.GetProperties();
            foreach (PropertyInfo prop in propinfo)
            {
                fieldList.Add(prop.Name);
            }

            return fieldList;

        }


        [TestInitialize()]
        public void MyClassInitialize()
        {
            APIKey = Token.GetToken();
        }

    }

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CongressAPI : CongressAPITestBase
    {


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
        public void coreNullAPIKeyException()
        {
            try
            {
                var CongressAPI = new CongressAPIRestClient("");
            }
            catch (CongressAPIHttpException e)
            {
                StringAssert.Contains(e.Message, "API Key is NULL");
                return;
            }

            Assert.Fail("API Key is NULL exception thrown for NULL key.");
  
        }

        [TestMethod]
        public void coreCorrectAPIKeyWorks()
        {
            try
            {   
                var CongressAPI = new CongressAPIRestClient(APIKey);
                Console.WriteLine("TestMethod: {0} - APIKey = {1}", MethodInfo.GetCurrentMethod().Name, APIKey);
            }
            catch (CongressAPIHttpException e)
            {
                Assert.Fail("Correct API Key caused Exception",e.Message);
                return;
            }


        }

    }
}
