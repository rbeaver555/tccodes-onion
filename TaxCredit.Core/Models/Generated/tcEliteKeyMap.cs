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

public partial class tcEliteKeyMap
{
    public int PK { get; set; }
    public int fkUniqueKey { get; set; }
    public int EliteKeyValue { get; set; }
    public bool IsActive { get; set; }

    public virtual tcUniqueKeyMap tcUniqueKeyMap { get; set; }
}
}
