using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Yardimci;

namespace IsTakipSistemiWeb.Veritabani
{
    public class Bildirim_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<Bildirim> Ekle(Bildirim data)
        {
            try
            {
                entity.Bildirim.Add(data);
                entity.SaveChanges();
                return new NIslemSonuc<Bildirim>
                {
                    basariliMi = true,
                    Veri = data,
                    mesaj = "Bildirim Kaydı Tamamlandı!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Bildirim>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Bildirim Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<List<ViewBildirim>> Listele()
        {
            try
            {
                List<ViewBildirim> liste = (from b in entity.Bildirim
                                            join t in entity.BildirimTur on b.tur_id equals t.tur_id
                                            select new ViewBildirim
                                            {
                                                arkaplan = t.arkaplan,
                                                turAd = t.ad,
                                                bildirimId = b.bildirim_id,
                                                goruldu_mu = b.goruldu_mu.Value,
                                                mesaj = b.mesaj,
                                                ikon_font = t.ikon_font,
                                                personel_tc = b.personel_tc,
                                                tarih = b.tarih.Value,
                                                sure_bilgisi = "Süre",
                                                turId = t.tur_id
                                            }).ToList();

                return new NIslemSonuc<List<ViewBildirim>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewBildirim>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Bildirim Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Bildirim Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
    }
}