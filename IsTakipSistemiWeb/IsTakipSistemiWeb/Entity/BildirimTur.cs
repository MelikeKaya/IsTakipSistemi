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
    
    public partial class BildirimTur
    {
        public BildirimTur()
        {
            this.Bildirim = new HashSet<Bildirim>();
        }
    
        public int tur_id { get; set; }
        public string ad { get; set; }
        public string arkaplan { get; set; }
        public string ikon_font { get; set; }
    
        public virtual ICollection<Bildirim> Bildirim { get; set; }
    }
}
