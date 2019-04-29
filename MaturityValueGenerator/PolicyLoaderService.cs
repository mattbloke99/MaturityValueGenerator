using MaturityValueGenerator;
using System.Collections.Generic;
using System.IO;

namespace MaturityValueGenerator
{
    public class PolicyLoaderService
    {
        private string v;

        public PolicyLoaderService(string filePath)
        {

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not load {filePath}");
            }

            IList<Policy> policies = new List<Policy>();



            using (StreamReader sr = new StreamReader(filePath))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    policies.Add(new Policy(line));
                }

                Policies = policies;
            }
        }

        public IEnumerable<Policy> Policies { get; set; }
    }
}