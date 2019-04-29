using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MaturityValueGenerator.Tests
{
    public class PolicyLoaderServiceTests
    {
        [Test]
        public void CreateXmlTest()
        {
            IEnumerable<Policy> policies = new List<Policy>()
            {
                new Policy("A100001,01/06/1986,10000,Y,1000,40"),
                new Policy("B100001,01/01/1995,12000,Y,2000,41"),
                new Policy("C100001,01/01/1992,13000,N,1000,42")
            };

            MaturityXmlService maturityXmlService = new MaturityXmlService(policies);

            XDocument xdoc = maturityXmlService.CreateXml();

            Assert.AreEqual(3, xdoc.Descendants("Policy").Count());
            Assert.IsNotEmpty(xdoc.Descendants("Policy").First().ToString());
            Assert.AreEqual("A100001", xdoc.Descendants("Policy").First().Element("Number").Value);
        }
    }
}

