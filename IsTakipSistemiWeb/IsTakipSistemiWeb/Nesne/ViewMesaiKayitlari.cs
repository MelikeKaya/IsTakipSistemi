using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewMesaiKayitlari
    {
        public int kayit_id { get; set; }
        public string personel_tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public DateTime tarih { get; set; }
        public TimeSpan giris_saat { get; set; }
        public TimeSpan cikis_saat { get; set; }
        public double giris_fark { get; set; }
        public double cikis_fark { get; set; }
        public double ek_mesai { get; set; }
        public int giris_zaman_farki { get; set; }
        public int cikis_zaman_farki { get; set; }
        public double toplam_zaman { get; set; }
    }
}