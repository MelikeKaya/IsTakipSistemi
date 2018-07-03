using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewIsListesi
    {
        public int is_id { get; set; }
        public int tur_id { get; set; }
        public string tur_adi { get; set; }
        public int durum_id { get; set; }
        public string durum_adi { get; set; }
        public string baslik { get; set; }
        public DateTime kayit_tarih { get; set; }
        public string firma_unvan { get; set; }
        public int firma_id { get; set; }
    }
}