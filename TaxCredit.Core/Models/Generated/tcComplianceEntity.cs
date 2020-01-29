//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace TaxCredit.Core.Models
{


using System;
using System.Collections.Generic;

public partial class tcComplianceEntity
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tcComplianceEntity()
    {
        this.tcComplianceRentRestrictionIncomeLimits = new HashSet<tcComplianceRentRestrictionIncomeLimit>();
    }

    public int PK { get; set; }
    public Nullable<int> fkComplianceEntityRelationship { get; set; }
    public Nullable<int> fkComplianceEntityType { get; set; }
    public Nullable<int> fkBuilding { get; set; }
    public Nullable<int> fkFamily { get; set; }
    public Nullable<decimal> AGMI40FamilyCount1 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount2 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount3 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount4 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount5 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount6 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount7 { get; set; }
    public Nullable<decimal> AGMI40FamilyCount8 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount1 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount2 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount3 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount4 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount5 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount6 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount7 { get; set; }
    public Nullable<decimal> AGMI50FamilyCount8 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount1 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount2 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount3 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount4 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount5 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount6 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount7 { get; set; }
    public Nullable<decimal> AGMI60FamilyCount8 { get; set; }
    public Nullable<decimal> GrossIncome { get; set; }
    public Nullable<decimal> GrossAssets { get; set; }
    public Nullable<decimal> TotalIncome { get; set; }
    public Nullable<bool> IsFamilyEligible { get; set; }
    public string PrimarySetAsideType { get; set; }
    public Nullable<int> PrimaryUnitCount { get; set; }
    public Nullable<decimal> PrimaryFootageCount { get; set; }
    public Nullable<decimal> PrimarySetAsideRequiredUnitCount { get; set; }
    public Nullable<decimal> PrimarySetAsideRequiredFootageCount { get; set; }
    public Nullable<decimal> PrimaryFootagePCT { get; set; }
    public Nullable<decimal> PrimaryUnitPCT { get; set; }
    public Nullable<bool> PrimaryApplicableFractionDroped { get; set; }
    public string SecondarySetAsideType { get; set; }
    public Nullable<int> SecondaryUnitCount { get; set; }
    public Nullable<decimal> SEcondaryFootageCount { get; set; }
    public Nullable<decimal> SecondarySetAsideRequiredUnitCount { get; set; }
    public Nullable<decimal> SecondarySetAsideRequiredFootageCount { get; set; }
    public Nullable<decimal> SecondaryUnitPCT { get; set; }
    public Nullable<decimal> SecondaryFootagePCT { get; set; }
    public Nullable<bool> SecondaryApplicableFractionDroped { get; set; }
    public Nullable<decimal> DeepRentSkewAFUnitCount { get; set; }
    public Nullable<decimal> DeepRentSkewAFFootageCount { get; set; }
    public Nullable<decimal> DeepRentSetAsideRequiredUnitCount { get; set; }
    public Nullable<decimal> DeepRentSetAsideRequiredFootageCount { get; set; }
    public Nullable<decimal> TotalSquareFootage { get; set; }
    public Nullable<decimal> CreditAllocationAvaliableUT { get; set; }
    public Nullable<decimal> CreditAllocationUTPercentage { get; set; }
    public Nullable<int> NumberofEligibleMembers { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<decimal> AGMI140Percent { get; set; }
    public Nullable<bool> isFamilyOverIncome { get; set; }
    public Nullable<bool> NeedAvailableUnitRule { get; set; }
    public Nullable<bool> AvailableMarketRentTics { get; set; }
    public string StudentValidException { get; set; }
    public Nullable<decimal> CurrentIncomeLimitFamilySize { get; set; }
    public string IncomeRestrictionMet { get; set; }
    public string IncomeRestrictionPercentage { get; set; }
    public Nullable<decimal> TotalCashValueofAssets { get; set; }
    public Nullable<decimal> TotalAnnualIncomeofAssets { get; set; }
    public Nullable<decimal> ImputedIncomefromAssets { get; set; }
    public Nullable<decimal> MaximumRentLimit { get; set; }
    public Nullable<System.DateTime> MoveInDate { get; set; }
    public Nullable<bool> IsUnitTransfer { get; set; }
    public Nullable<int> HouseholdSizeAtMoveIn { get; set; }
    public Nullable<decimal> IncomeLimitAtMoveIn { get; set; }

    public virtual tcComplianceEntityType tcComplianceEntityType { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<tcComplianceRentRestrictionIncomeLimit> tcComplianceRentRestrictionIncomeLimits { get; set; }
}
}
