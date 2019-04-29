using System;

namespace MaturityValueGenerator
{
    public class PolicyA : Policy
    {
        public PolicyA(string csvString) : base(csvString)
        {
            ManagementFeePercentage = 3;
        }

        public override bool QualifiesForDiscretionaryBonus
        {
            get
            {

                return PolicyStartDate < new DateTime(1990, 1, 1);
            }
        }

    }
}

