//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsTakipSistemiWeb.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonelTip
    {
        public PersonelTip()
        {
            this.Personel = new HashSet<Personel>();
        }
    
        public int tip_id { get; set; }
        public string ad { get; set; }
        public Nullable<double> varsayilan_maas { get; set; }
    
        public virtual ICollection<Personel> Personel { get; set; }
    }
}