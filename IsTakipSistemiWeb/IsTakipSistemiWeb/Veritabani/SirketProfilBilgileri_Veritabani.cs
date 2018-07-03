using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class SirketProfilBilgileri_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<SirketProfilBilgileri> DetayGetir()
        {
            try
            {
                SirketProfilBilgileri data = entity.SirketProfilBilgileri.FirstOrDefault();
                if (data != null)
                {
                    return new NIslemSonuc<SirketProfilBilgileri>
                    {
                        basariliMi = true,
                        Veri = data
                    };
                }
                else
                {
                    return new NIslemSonuc<SirketProfilBilgileri>
                    {
                        basariliMi = false,
                        mesaj = "Profil Kayıtlı Değil!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<SirketProfilBilgileri>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "SirketProfilBilgileri Veritabani",
                        aciklama = "Detay Getir",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<SirketProfilBilgileri> Guncelle(SirketProfilBilgileri data)
        {
            try
            {
                entity.SirketProfilBilgileri.Attach(data);
                var entry = entity.Entry(data);
                entry.State = EntityState.Modified;
                entity.SaveChanges();

                return new NIslemSonuc<SirketProfilBilgileri>
                {
                    basariliMi = true,
                    mesaj = "Güncelleme İşlemi Tamamlandı!",
                    Veri = data
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<SirketProfilBilgileri>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Güncelleme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "SirketProfilBilgileri Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
    }
}