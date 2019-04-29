using MaturityValueGenerator;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    public class PolicyLoaderServiceTests
    {
        [Test]
        public void LoadCsvTest()
        {
            PolicyLoaderService loaderService = new PolicyLoaderService(@"C:\Users\Matt\source\repos\MaturityValueGenerator\MaturityData.csv");

            Assert.IsInstanceOf<IEnumerable<Policy>>(loaderService.Policies);
            Assert.AreEqual(9, loaderService.Policies.Count());
        }

        [Test]
        public void LoadCsvFileNotFoundTest()
        {
            Assert.Throws<FileNotFoundException>(() => new PolicyLoaderService(@"BADFILENAME"));
        }
    }
}

