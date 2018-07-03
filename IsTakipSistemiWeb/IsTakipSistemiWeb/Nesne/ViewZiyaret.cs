using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewZiyaret
    {
        public int ziyaretId { get; set; }
        public string tur { get; set; }
        public string firma { get; set; }
        public string personelAdSoyad { get; set; }
        public DateTime girisTarih { get; set; }
        public DateTime cikisTarih { get; set; }
        public double girisUzaklik { get; set; }
        public double cikisUzaklik { get; set; }
        public bool goruldu_mu { get; set; }
        public TimeSpan saat { get; set; }
    }
}