using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using System.Data;
using System.Data.Entity;

namespace IsTakipSistemiWeb.Veritabani
{
    public class Is_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<Is> DetayGetir(int id)
        {
            try
            {
                Is data = entity.Is.Where(u => u.is_id == id).FirstOrDefault();
                if (data != null)
                {
                    return new NIslemSonuc<Is>
                    {
                        basariliMi = true,
                        Veri = data
                    };
                }
                else
                {
                    return new NIslemSonuc<Is>
                    {
                        basariliMi = false,
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Is>
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
        public NIslemSonuc<List<ViewIsListesi>> Listele()
        {
            try
            {
                List<ViewIsListesi> liste = (from i in entity.Is
                                             join f in entity.Firma on i.firma_id equals f.firma_id
                                             join d in entity.IsDurum on i.durum_id equals d.durum_id
                                             join t in entity.IsTur on i.tur_id equals t.tur_id
                                             where i.silindi_mi == false
                                             select new ViewIsListesi
                                             {
                                                 baslik = i.baslik,
                                                 durum_adi = d.ad,
                                                 tur_id = t.tur_id,
                                                 durum_id = d.durum_id,
                                                 tur_adi = t.ad,
                                                 firma_id = f.firma_id,
                                                 firma_unvan = f.unvan,
                                                 is_id = i.is_id,
                                                 kayit_tarih = i.kayit_tarih.Value
                                             }).ToList();

                return new NIslemSonuc<List<ViewIsListesi>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewIsListesi>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "İş Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "İş Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<Is> Ekle(Is data)
        {
            try
            {
                entity.Is.Add(data);
                entity.SaveChanges();
                return new NIslemSonuc<Is>
                {
                    basariliMi = true,
                    Veri = data,
                    mesaj = "İş Kaydı Başarıyla Tamamlandı!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Is>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "İş Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<Is> Guncelle(Is data)
        {
            try
            {
                entity.Is.Attach(data);
                var entry = entity.Entry(data);
                entry.State = EntityState.Modified;
                entity.SaveChanges();

                return new NIslemSonuc<Is>
                {
                    basariliMi = true,
                    mesaj = "Güncelleme İşlemi Tamamlandı!",
                    Veri = data
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Is>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Güncelleme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "İş Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<Is> Sil(int id)
        {
            try
            {
                Is data = (from i in entity.Is where i.is_id == id select i).FirstOrDefault();
                data.silindi_mi = true;
                entity.SaveChanges();
                return new NIslemSonuc<Is>
                {
                    basariliMi = true,
                    mesaj = "Silme İşlemi Tamamlandı!",
                    Veri = data
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Is>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Silme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "İş Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
    }
}