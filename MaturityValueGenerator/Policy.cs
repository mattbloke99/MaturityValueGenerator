using System;

namespace MaturityValueGenerator
{
    public class Policy
    {
        public Policy(string csvString)
        {
            var items = csvString.Split(",");

            if (items.Length != 6)
            {
                throw new ApplicationException($"Wrong number of items found in CSV. CSV was {csvString}");
            }

            //to make this more robust TryParse could be used and errors throw if problems are encountered.
            PolicyNumber = items[0];
            PolicyStartDate = DateTime.Parse(items[1]);
            Premiums = decimal.Parse(items[2]);
            HasMembershipRights = items[3].Equals("Y", StringComparison.InvariantCultureIgnoreCase);
            DiscretionaryBonus = decimal.Parse(items[4]);
            UpliftPercentage = decimal.Parse(items[5]);
        }

        public string PolicyNumber { get;  set; }
        public DateTime PolicyStartDate { get;  set; }
        public decimal Premiums { get;  set; }
        public bool HasMembershipRights { get;  set; }
        public decimal DiscretionaryBonus { get;  set; }
        public decimal UpliftPercentage { get;  set; }

        public decimal CalculateMaturityValue()
        {
            //maturity value = premiums – management fee) + discretionary bonus if qualifying) *uplift
            var managementFees = Premiums * CalculateManagementFeePercentage() / 100;

            return (Premiums - managementFees + DiscretionaryBonus) * (UpliftPercentage + 100) / 100;
        }

        public decimal CalculateManagementFeePercentage()
        {
            if (PolicyStartDate < new DateTime(1990, 1, 1))
            {
                return 3;
            }

            if (HasMembershipRights)
            {
                return 5;
            }
            else
            {
                if (PolicyStartDate >= new DateTime(1990, 1, 1))
                {
                    return 7;
                }
            }

            throw new ApplicationException("Unrecognised policy type");
        }
    }
}

