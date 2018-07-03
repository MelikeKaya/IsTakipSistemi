using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewDosya
    {
        public int dosyaId { get; set; }
        public int kategoriId { get; set; }
        public int firmaId { get; set; }
        public string baslik { get; set; }
        public string yol { get; set; }
        public DateTime tarih { get; set; }
        public bool silindiMi { get; set; }
        public string kategoriAd { get; set; }
        public string FirmaAd { get; set; }
    }
}