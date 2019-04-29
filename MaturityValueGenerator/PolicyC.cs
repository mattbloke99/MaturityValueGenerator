using System;

namespace MaturityValueGenerator
{
    public class PolicyC : Policy
    {
        public PolicyC(string csvString) : base(csvString)
        {
            ManagementFeePercentage = 7;
        }

        public override bool QualifiesForDiscretionaryBonus
        {
            get
            {

                return PolicyStartDate >= new DateTime(1990, 1, 1) && HasMembershipRights;
            }
        }

    }
}

