using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class IsTur_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<IsTur>> Listele()
        {
            try
            {
                List<IsTur> liste = entity.IsTur.ToList();

                return new NIslemSonuc<List<IsTur>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<IsTur>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "İş Türü Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "IsTur Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<IsTur> Ekle(IsTur eklenecek)
        {
            try
            {
                entity.IsTur.Add(eklenecek);
                entity.SaveChanges();
                return new NIslemSonuc<IsTur>
                {
                    basariliMi = true,
                    Veri = eklenecek,
                    mesaj = "Tür Kaydı Tamamlandı.."
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<IsTur>
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
        public NIslemSonuc<IsTur> DetayGetir(int id)
        {
            try
            {
                IsTur data = entity.IsTur.Where(u => u.tur_id == id).FirstOrDefault();
                if (data != null)
                {
                    return new NIslemSonuc<IsTur>
                    {
                        basariliMi = true,
                        Veri = data
                    };
                }
                else
                {
                    return new NIslemSonuc<IsTur>
                    {
                        basariliMi = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<IsTur>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "Is Veritabani",
                        aciklama = "Detay Getir",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}