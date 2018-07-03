using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class IsDurum_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<IsDurum>> Listele()
        {
            try
            {
                List<IsDurum> liste = entity.IsDurum.ToList();

                return new NIslemSonuc<List<IsDurum>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<IsDurum>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "İş Durum Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "IsDurum Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<IsDurum> Ekle(IsDurum eklenecek)
        {
            try
            {
                entity.IsDurum.Add(eklenecek);
                entity.SaveChanges();
                return new NIslemSonuc<IsDurum>
                {
                    basariliMi = true,
                    Veri = eklenecek,
                    mesaj = "Durum Kaydı Tamamlandı.."
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<IsDurum>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "IsDurum Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}