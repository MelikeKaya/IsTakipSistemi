using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class FirmaDurum_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<List<FirmaDurum>> Listele()
        {
            try
            {
                List<FirmaDurum> liste = (from d in entity.FirmaDurum select d).ToList();
                return new NIslemSonuc<List<FirmaDurum>>
                {
                    basariliMi = true,
                    Veri = liste,
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<FirmaDurum>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Listeleme Metodunda Hata",
                        mesaj = ex.Message,
                        sinif = "FirmaDurum Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistem Hatası"
                };
            }
        }
    }
}