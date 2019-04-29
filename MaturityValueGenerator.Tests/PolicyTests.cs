using System;
using MaturityValueGenerator;
using NUnit.Framework;

namespace Tests
{
    public class PolicyTests
    {
        [Test]
        public void CreatePolicyTest()
        {
            Policy policy = new Policy("A100001,01/06/1986,10000,Y,1000,40");

            Assert.AreEqual("A100001", policy.PolicyNumber);
            Assert.AreEqual(new DateTime(1986, 6, 1), policy.PolicyStartDate);
            Assert.AreEqual(10000, policy.Premiums);
            Assert.AreEqual(true, policy.HasMembershipRights);
            Assert.AreEqual(1000, policy.DiscretionaryBonus);
            Assert.AreEqual(40, policy.UpliftPercentage);
        }

        [Test]
        public void CreatePolicyTooManyItemsTest()
        {
            Assert.Throws<ApplicationException>(() => new Policy("A100001,01/06/1986,10000,Y,1000,40,EXTRAITEM"));
        }


        [Test]
        public void CalculateManagementFeePolicyTypeATest()
        {
            Policy policy = new Policy("A100001,01/06/1986,10000,Y,1000,40");

            Assert.AreEqual(3, policy.CalculateManagementFeePercentage());
        }

        [Test]
        public void CalculateManagementFeePolicyTypeBTest()
        {
            Policy policy = new Policy("B100001,01/01/1995,12000,Y,2000,41");

            Assert.AreEqual(5, policy.CalculateManagementFeePercentage());
        }

        [Test]
        public void CalculateManagementFeePolicyTypeCTest()
        {
            Policy policy = new Policy("C100001,01/01/1992,13000,N,1000,42");

            Assert.AreEqual(7, policy.CalculateManagementFeePercentage());
        }

        [Test]
        public void CalculateMaturityValueTest()
        {
            Policy policy = new Policy("A100001,01/06/1986,10000,Y,1000,40");

            Assert.AreEqual(14980, policy.CalculateMaturityValue());
        }
    }
}

