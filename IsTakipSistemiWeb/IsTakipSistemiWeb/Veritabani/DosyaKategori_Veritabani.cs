using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class DosyaKategori_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<DosyaKategori>> Listele()
        {
            try
            {
                List<DosyaKategori> liste = (from d in entity.DosyaKategori where d.silindi_mi == false select d).ToList();
                return new NIslemSonuc<List<DosyaKategori>>
                {
                    basariliMi = true,
                    Veri = liste,
                    mesaj = "Kategori Ekleme Başarılı"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<DosyaKategori>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Listeleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "DosyaKategori Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistem Hatası"
                };
            }
        }
    }
}