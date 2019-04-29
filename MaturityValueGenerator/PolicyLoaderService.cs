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

            IList<Policy> policies = new List<Policy>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string headerLine = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    var policyType = line.Substring(0, 1);



                    switch (policyType)
                    {
                        case "A":
                            policies.Add(new PolicyA(line));
                            break;
                        case "B":
                            policies.Add(new PolicyB(line));
                            break;
                        case "C":
                            policies.Add(new PolicyC(line));
                            break;
                        default:
                            break;
                    }


                    
                }

                Policies = policies;
            }
        }

        public IEnumerable<Policy> Policies { get; set; }
    }
}