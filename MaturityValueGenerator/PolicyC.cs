using System;

namespace MaturityValueGenerator
{
    public class PolicyC : Policy
    {
        public PolicyC() => ManagementFeePercentage = 7;

        public override bool QualifiesForDiscretionaryBonus => PolicyStartDate >= new DateTime(1990, 1, 1) && HasMembershipRights;

    }
}

