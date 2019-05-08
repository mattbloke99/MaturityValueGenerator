namespace MaturityValueGenerator
{
    public class PolicyB : Policy
    {
        public PolicyB() => ManagementFeePercentage = 5;

        public override bool QualifiesForDiscretionaryBonus => HasMembershipRights;

    }
}

