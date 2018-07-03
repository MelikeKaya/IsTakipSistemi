using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class NIslemSonuc<T>
    {
        // Veritabanında Yapılan İşlemin Sonucunu Tutan Sınıftır.
        public bool basariliMi { get; set; } // İşlem başarılıysa true, değilse false
        public T Veri { get; set; } // İşlem sonucunda dönecek veri
        public NHata hata { get; set; } // Hata oluşursa doldurulacak hata nesnesi
        public string mesaj { get; set; } // Kullanıcıya gösterilecek mesaj
    }
}