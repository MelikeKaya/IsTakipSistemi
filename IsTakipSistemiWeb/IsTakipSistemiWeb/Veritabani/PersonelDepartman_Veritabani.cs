using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class PersonelDepartman_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<ViewDepartman>> Listele()
        {
            try
            {
                List<ViewDepartman> liste = (from d in entity.PersonelDepartman
                                             join p in entity.Personel on d.sorumlu_personel_tc equals p.personel_tc
                                             orderby d.ad
                                             select new ViewDepartman
                                             {
                                                 ad = d.ad,
                                                 departman_id = d.departman_id,
                                                 sorumlu_personel = p.ad + " " + p.soyad
                                             }).ToList();
                return new NIslemSonuc<List<ViewDepartman>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewDepartman>>
                {
                    basariliMi = true,
                    mesaj = "Sistem Hatası",
                    hata = new NHata
                    {
                        aciklama = "Departman Listelemede Hata",
                        mesaj = ex.Message,
                        sinif = "PersonelDepartman_Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<int> Ekle(PersonelDepartman departman)
        {
            try
            {
                entity.PersonelDepartman.Add(departman);
                entity.SaveChanges();
                return new NIslemSonuc<int>
                {
                    basariliMi = true,
                    Veri = departman.departman_id,
                    mesaj = "Departman Kaydı Başarılı!"
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
                        strace = ex.StackTrace,
                        sinif = "PersonelDepartman Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}