namespace MaturityValueGenerator
{
    public class PolicyFactory
    {
        public IPolicy CreatePolicy(string policyType, string line)
        {
            IPolicy policy = null;
            switch (policyType)
            {
                case "A":
                    policy = new PolicyA().LoadLine(line);
                    break;

                case "B":
                    policy = new PolicyB().LoadLine(line);
                    break;

                case "C":
                    policy = new PolicyC().LoadLine(line);
                    break;
                default:
                    break;

            }
            return policy;

        }
    }
}