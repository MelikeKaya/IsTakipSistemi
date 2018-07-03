using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class NHata
    {
        // Hata kaydını içeren sınıftır. TRY-CATCH olayından dönen verileri saklar
        public string sinif { get; set; } // Hatanın alındığı sınıfı gösterir
        public string aciklama { get; set; } // Hatanın açıklamasını gösterir
        public DateTime tarih { get; set; } // Tarih
        public string mesaj { get; set; } // Hata Mesajı
        public string strace { get; set; } // Hata Stack Raporu
    }
}