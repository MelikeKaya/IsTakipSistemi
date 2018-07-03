using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewGorevlendirme
    {
        public int kayit_id { get; set; }
        public int is_id { get; set; }
        public string personel_tc { get; set; }
        public string personelAdSoyad { get; set; }
        public string isBaslik { get; set; }
        public string aciklama { get; set; }
        public DateTime? baslangic { get; set; }
        public DateTime? bitis { get; set; }
    }
}