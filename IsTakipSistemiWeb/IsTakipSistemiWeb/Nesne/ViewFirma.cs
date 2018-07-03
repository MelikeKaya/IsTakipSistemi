using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewFirma
    {
        public int firma_id { get; set; }
        public string cari_kod { get; set; }
        public string durum { get; set; }
        public string sgk_no { get; set; }
        public string unvan { get; set; }
        public string telefon { get; set; }
        public string mail { get; set; }
        public string arkaplan_rengi { get; set; }
    }
}