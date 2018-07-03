using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class Dosya_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<int> Ekle(Dosya dosya)
        {
            try
            {
                entity.Dosya.Add(dosya);
                entity.SaveChanges();
                return new NIslemSonuc<int>
                {
                    basariliMi = true,
                    Veri = dosya.dosya_id,
                    mesaj = "Dosya Ekleme Başarılı"
                };
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<int>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "Dosya Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = ex.Message
                };
            }
        }
        public NIslemSonuc<List<ViewDosya>> Listele()
        {
            try
            {
                List<ViewDosya> liste = (from d in entity.Dosya
                                         join k in entity.DosyaKategori on d.kategori_id equals k.kategori_id
                                         join f in entity.Firma on d.iliskili_firma_id equals f.firma_id
                                         where d.silindi_mi == false
                                         select new ViewDosya
                                         {
                                             baslik = d.baslik,
                                             dosyaId = d.dosya_id,
                                             FirmaAd = f.kisa_ad,
                                             kategoriAd = k.ad,
                                             firmaId = d.iliskili_firma_id.Value,
                                             kategoriId = k.kategori_id,
                                             silindiMi = d.silindi_mi.Value,
                                             tarih = d.tarih.Value,
                                             yol = d.yol
                                         }).ToList();
                return new NIslemSonuc<List<ViewDosya>>
                {
                    basariliMi = true,
                    Veri = liste,
                    mesaj = "Dosya Listeleme Başarılı"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewDosya>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Listeleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "Dosya Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistem Hatası"
                };
            }
        }
    }
}