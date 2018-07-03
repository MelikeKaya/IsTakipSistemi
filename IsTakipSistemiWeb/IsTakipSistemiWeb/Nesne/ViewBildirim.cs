using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewBildirim
    {
        public int bildirimId { get; set; }
        public int turId { get; set; }
        public string personel_tc { get; set; }
        public string mesaj { get; set; }
        public DateTime tarih { get; set; }
        public string sure_bilgisi { get; set; }
        public bool goruldu_mu { get; set; }
        public string turAd { get; set; }
        public string arkaplan { get; set; }
        public string ikon_font { get; set; }
    }
}