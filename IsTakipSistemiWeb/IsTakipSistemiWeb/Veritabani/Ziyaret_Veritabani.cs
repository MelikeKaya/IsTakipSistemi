using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class Ziyaret_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<int> Ekle(Ziyaret ziyaret)
        {
            try
            {
                entity.Ziyaret.Add(ziyaret);
                entity.SaveChanges();
                return new NIslemSonuc<int>
                {
                    basariliMi = true,
                    Veri = ziyaret.ziyaret_id,
                    mesaj = "Ziyaret Kaydı Başarılı"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<int>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "Ziyaret Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = ex.Message
                };
            }
        }
        public NIslemSonuc<List<ViewZiyaret>> Listele()
        {
            try
            {
                List<ViewZiyaret> liste = (from z in entity.Ziyaret
                                           join t in entity.ZiyaretTur on z.tur_id equals t.tur_id
                                           join f in entity.Firma on z.firma_id equals f.firma_id
                                           join p in entity.Personel on z.personel_tc equals p.personel_tc
                                           select new ViewZiyaret
                                           {
                                               ziyaretId = z.ziyaret_id,
                                               tur = t.ad,
                                               personelAdSoyad = p.ad + " " + p.soyad,
                                               firma = f.unvan,
                                               girisTarih = z.giris_tarih.Value,
                                               cikisTarih = z.cikis_tarih.Value,
                                               cikisUzaklik = z.cikis_fark.Value,
                                               girisUzaklik = z.giris_fark.Value,
                                               goruldu_mu = z.bildirim_goruldu_mu.Value,
                                               saat = z.saat.Value
                                           }).ToList();
                return new NIslemSonuc<List<ViewZiyaret>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewZiyaret>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Listeleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "Ziyaret Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistem Hatası"
                };
            }
        }
        public NIslemSonuc<Ziyaret> DetayGetir(int id)
        {
            try
            {
                Ziyaret ziyaret = entity.Ziyaret.Where(u => u.ziyaret_id == id).FirstOrDefault();
                if (ziyaret != null)
                {
                    return new NIslemSonuc<Ziyaret>
                    {
                        basariliMi = true,
                        Veri = ziyaret
                    };
                }
                else
                {
                    return new NIslemSonuc<Ziyaret>
                    {
                        basariliMi = false,
                        mesaj = "Ziyaret Kayıtlı Değil!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Ziyaret>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "Ziyaret Veritabani",
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