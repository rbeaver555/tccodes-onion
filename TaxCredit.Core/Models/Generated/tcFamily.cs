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

public partial class tcFamily
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tcFamily()
    {
        this.tcFamilyMembers = new HashSet<tcFamilyMember>();
        this.tcHistoricalOccupancies = new HashSet<tcHistoricalOccupancy>();
        this.tcOccupancies = new HashSet<tcOccupancy>();
        this.tcTICs = new HashSet<tcTIC>();
    }

    public int PK { get; set; }
    public Nullable<bool> IsFamilyEligible { get; set; }
    public Nullable<System.DateTime> NextRecertificationDate { get; set; }
    public bool IsActive { get; set; }
    public string ExternalKey { get; set; }
    public Nullable<bool> IsFullTimeResidentialWorker { get; set; }
    public string transactionKey { get; set; }
    public System.DateTime EffectiveDate { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<tcFamilyMember> tcFamilyMembers { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<tcHistoricalOccupancy> tcHistoricalOccupancies { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<tcOccupancy> tcOccupancies { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<tcTIC> tcTICs { get; set; }
}
}
