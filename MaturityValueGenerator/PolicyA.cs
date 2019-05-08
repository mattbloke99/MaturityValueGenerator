using System;

namespace MaturityValueGenerator
{
    public class PolicyA : Policy
    {
        public PolicyA()  => ManagementFeePercentage = 3;

        public override bool QualifiesForDiscretionaryBonus => PolicyStartDate < new DateTime(1990, 1, 1);

    }
}

