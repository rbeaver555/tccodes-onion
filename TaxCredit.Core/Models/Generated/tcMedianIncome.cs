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

public partial class tcMedianIncome
{
    public int PK { get; set; }
    public decimal MedianIncome1Person { get; set; }
    public decimal MedianIncome2Person { get; set; }
    public decimal MedianIncome3Person { get; set; }
    public decimal MedianIncome4Person { get; set; }
    public decimal MedianIncome5Person { get; set; }
    public decimal MedianIncome6Person { get; set; }
    public decimal MedianIncome7Person { get; set; }
    public decimal MedianIncome8Person { get; set; }
    public System.DateTime StartDate { get; set; }
    public System.DateTime EndDate { get; set; }
    public string ExternalKey { get; set; }
    public bool IsActive { get; set; }
    public int fkProperty { get; set; }
    public string transactionKey { get; set; }

    public virtual tcProperty tcProperty { get; set; }
}
}
