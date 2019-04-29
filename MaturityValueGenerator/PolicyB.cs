namespace MaturityValueGenerator
{
    public class PolicyB : Policy
    {
        public PolicyB(string csvString) : base(csvString)
        {
            ManagementFeePercentage = 5;
        }

        public override bool  QualifiesForDiscretionaryBonus
        {
            get
            {

                return HasMembershipRights;
            }
        }

    }
}

