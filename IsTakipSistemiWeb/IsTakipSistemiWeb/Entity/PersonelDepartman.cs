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
    
    public partial class PersonelDepartman
    {
        public PersonelDepartman()
        {
            this.Personel = new HashSet<Personel>();
        }
    
        public int departman_id { get; set; }
        public string ad { get; set; }
        public string sorumlu_personel_tc { get; set; }
    
        public virtual ICollection<Personel> Personel { get; set; }
    }
}