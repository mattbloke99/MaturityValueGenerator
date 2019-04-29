using System.Collections.Generic;
using System.Xml.Linq;

namespace MaturityValueGenerator
{
    public class MaturityCalculatorService
    {
        private IEnumerable<Policy> policies;

        public MaturityCalculatorService(IEnumerable<Policy> policies)
        {
            this.policies = policies;
        }

        public void ExportToXml(string filename)
        {
            XElement xmlPolicies = new XElement("Policies");

            foreach (var policy in policies)
            {
                xmlPolicies.Add(CreatePolicyElement(policy));
            }

            XDocument doc = new XDocument(xmlPolicies);

            doc.Save(filename);
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