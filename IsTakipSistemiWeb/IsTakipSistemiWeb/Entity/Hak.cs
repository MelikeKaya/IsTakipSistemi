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
    
    public partial class Hak
    {
        public Hak()
        {
            this.RolHak = new HashSet<RolHak>();
        }
    
        public int hak_id { get; set; }
        public string ad { get; set; }
        public string link_id { get; set; }
        public string ust_link_id { get; set; }
    
        public virtual ICollection<RolHak> RolHak { get; set; }
    }
}
