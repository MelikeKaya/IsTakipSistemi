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
    
    public partial class Rol
    {
        public Rol()
        {
            this.Personel = new HashSet<Personel>();
            this.RolHak = new HashSet<RolHak>();
        }
    
        public int rol_id { get; set; }
        public string ad { get; set; }
    
        public virtual ICollection<Personel> Personel { get; set; }
        public virtual ICollection<RolHak> RolHak { get; set; }
    }
}