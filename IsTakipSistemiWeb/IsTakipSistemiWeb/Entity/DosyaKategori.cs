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
    
    public partial class DosyaKategori
    {
        public DosyaKategori()
        {
            this.Dosya = new HashSet<Dosya>();
        }
    
        public int kategori_id { get; set; }
        public string ekleyen_personel_tc { get; set; }
        public string ad { get; set; }
        public Nullable<System.DateTime> eklenme_tarih { get; set; }
        public Nullable<bool> silindi_mi { get; set; }
    
        public virtual Personel Personel { get; set; }
        public virtual ICollection<Dosya> Dosya { get; set; }
    }
}
