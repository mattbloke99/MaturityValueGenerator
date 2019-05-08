using System;

namespace MaturityValueGenerator
{
    public interface IPolicy
    {
        decimal DiscretionaryBonus { get; set; }
        bool HasMembershipRights { get; set; }
        decimal ManagementFeePercentage { get; set; }
        string PolicyNumber { get; set; }
        DateTime PolicyStartDate { get; set; }
        decimal Premiums { get; set; }
        bool QualifiesForDiscretionaryBonus { get; set; }
        decimal UpliftPercentage { get; set; }

        decimal CalculateMaturityValue();
        void LoadLine(string csvString);
    }
}