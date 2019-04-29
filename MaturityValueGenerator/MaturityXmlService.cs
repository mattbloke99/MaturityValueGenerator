using System.Collections.Generic;
using System.Xml.Linq;

namespace MaturityValueGenerator
{
    public class MaturityXmlService
    {
        private IEnumerable<Policy> policies;

        public MaturityXmlService(IEnumerable<Policy> policies)
        {
            this.policies = policies;
        }

        public XDocument CreateXml()
        {
            XElement xmlPolicies = new XElement("Policies");

            foreach (var policy in policies)
            {
                xmlPolicies.Add(CreatePolicyElement(policy));
            }

            return new XDocument(xmlPolicies);
        }
   
        private XElement CreatePolicyElement(Policy policy)
        {
            XElement xmlPolicy = new XElement("Policy");
            xmlPolicy.Add(new XElement("Number", policy.PolicyNumber));
            xmlPolicy.Add(new XElement("MaturityValue", policy.CalculateMaturityValue()));
            return xmlPolicy;
        }
    }
}