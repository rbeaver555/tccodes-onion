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

public partial class tcComplianceRuleTarget
{
    public int PK { get; set; }
    public string ComplianceRuleTarget { get; set; }
    public Nullable<int> fkComplianceRule { get; set; }
    public Nullable<bool> IsActive { get; set; }

    public virtual tcComplianceRule tcComplianceRule { get; set; }
}
}
