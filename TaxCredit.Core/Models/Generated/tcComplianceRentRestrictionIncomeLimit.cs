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

public partial class tcComplianceRentRestrictionIncomeLimit
{
    public int PK { get; set; }
    public Nullable<int> fktcComplianceEntity { get; set; }
    public string RentRestrictionPercent { get; set; }
    public Nullable<decimal> IncomeLimit { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; }
    public Nullable<decimal> MaxRent { get; set; }

    public virtual tcComplianceEntity tcComplianceEntity { get; set; }
}
}
