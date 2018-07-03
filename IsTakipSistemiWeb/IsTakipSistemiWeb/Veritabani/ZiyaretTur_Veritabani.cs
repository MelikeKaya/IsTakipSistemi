using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class ZiyaretTur_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<ZiyaretTur>> Listele()
        {
            try
            {
                List<ZiyaretTur> liste = entity.ZiyaretTur.ToList();

                return new NIslemSonuc<List<ZiyaretTur>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ZiyaretTur>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ziyaret Türü Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Ziyaret Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<ZiyaretTur> Ekle(ZiyaretTur eklenecek)
        {
            try
            {
                entity.ZiyaretTur.Add(eklenecek);
                entity.SaveChanges();
                return new NIslemSonuc<ZiyaretTur>
                {
                    basariliMi = true,
                    Veri = eklenecek,
                    mesaj = "Tür Kaydı Tamamlandı.."
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<ZiyaretTur>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Ziyaret Tür Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}