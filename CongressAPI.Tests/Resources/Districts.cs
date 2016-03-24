using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CongressAPI;
using CongressAPI.Model;

namespace CongressAPI.Tests
{
    [TestClass]
    public class Districts : CongressAPITestBase
    {
        [TestMethod]
        public void districtResourceWillReturnforZip()
        {
            
            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetDistrictsByZip("98033");
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Results.Count() > 0,"No Results returned");
            Assert.IsTrue(l.Results[0].state == "WA", String.Format("Results[0].state != WA state = {0}",l.Results[0].state));  // Hard coded for the current district alignment
            Assert.IsTrue(l.Results[0].district == 9, String.Format("Results[0].district != 9 district = {0}", l.Results[0].district));  // Hard coded for the current district alignment

        }

        [TestMethod]
        public void districtResourcebyZipBadZipEmptyResults()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetDistrictsByZip("9803365");
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Results.Count() == 0);
        }

        [TestMethod]
        public void districtResourceWillReturnforLatLong()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetDistrictsByLatLong(42.96,-108.09);
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Results.Count() == 1);      // Hard coded for the current district alignment
            Assert.IsTrue(l.Results[0].state == "WY");  // Hard coded for the current district alignment
            Assert.IsTrue(l.Results[0].district == 0);  // Hard coded for the current district alignment

        }

        [TestMethod]
        public void districtResourceBadLatLongEmptyResults()
        {

            var CongressAPI = new CongressAPIRestClient(APIKey);
            var l = CongressAPI.GetDistrictsByLatLong(99942.96, -9999108.09);
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Results.Count() == 0);      // Return no results

        }


    }
}
