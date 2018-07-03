using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class PersonelTip_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();
        
        public NIslemSonuc<List<PersonelTip>> Listele()
        {
            try
            {
                List<PersonelTip> liste = (from t in entity.PersonelTip orderby t.ad select t).ToList();
                return new NIslemSonuc<List<PersonelTip>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<List<PersonelTip>>
                {
                    basariliMi = true,
                    mesaj = "Sistem Hatası",
                    hata = new NHata
                    {
                        aciklama = "Tip Listelemede Hata",
                        mesaj = ex.Message,
                        sinif = "PersonelTip_Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<int> Ekle(PersonelTip tip)
        {
            try
            {
                entity.PersonelTip.Add(tip);
                entity.SaveChanges();
                return new NIslemSonuc<int>
                {
                    basariliMi = true,
                    Veri = tip.tip_id,
                    mesaj = "Tip Kaydı Başarılı!"
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
                        sinif = "PersonelTip Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}