using System.Collections.Generic;
using System.IO;

namespace MaturityValueGenerator
{
    public class PolicyLoaderService
    {
        public PolicyLoaderService(string filePath)
        {

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not load {filePath}");
            }

            IList<IPolicy> policies = new List<IPolicy>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                PolicyFactory policyFactory = new PolicyFactory();

                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    var policyType = line.Substring(0, 1);

                    IPolicy policy = policyFactory.CreatePolicy(policyType, line);

                    policies.Add(policy);

                }

                Policies = policies;
            }
        }

        public IEnumerable<IPolicy> Policies { get; set; }
    }
}