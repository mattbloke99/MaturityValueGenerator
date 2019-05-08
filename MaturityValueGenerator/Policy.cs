using System;

namespace MaturityValueGenerator
{
    public abstract class Policy : IPolicy
    {
        public Policy LoadLine(string csvString)
        {
            var items = csvString.Split(",");

            if (items.Length != 6)
            {
                throw new ApplicationException($"Wrong number of items found in CSV. CSV was {csvString}");
            }

            //to make this more robust TryParse could be used and errors thrown if problems are encountered.
            //it would also be worthwhile validating the policy number length and format
            PolicyNumber = items[0];
            PolicyStartDate = DateTime.Parse(items[1]);
            Premiums = decimal.Parse(items[2]);
            HasMembershipRights = items[3].Equals("Y", StringComparison.InvariantCultureIgnoreCase);
            DiscretionaryBonus = decimal.Parse(items[4]);
            UpliftPercentage = decimal.Parse(items[5]);

            return this;
        }

        public string PolicyNumber { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public decimal Premiums { get; set; }
        public bool HasMembershipRights { get; set; }
        public decimal DiscretionaryBonus { get; set; }
        public decimal UpliftPercentage { get; set; }
        public decimal ManagementFeePercentage { get; set; }

        public virtual bool QualifiesForDiscretionaryBonus { get; set; }

        public decimal CalculateMaturityValue()
        {
            //maturity value = premiums – management fee) + discretionary bonus if qualifying) *uplift
            var managementFees = Premiums * ManagementFeePercentage / 100;
            var actualBonus = QualifiesForDiscretionaryBonus ? DiscretionaryBonus : 0;

            return (Premiums - managementFees + actualBonus) * (UpliftPercentage + 100) / 100;
        }

        void IPolicy.LoadLine(string csvString)
        {
            throw new NotImplementedException();
        }
    }
}

