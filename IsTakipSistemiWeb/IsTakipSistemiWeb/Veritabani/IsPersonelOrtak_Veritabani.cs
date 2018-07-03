using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Yardimci;

namespace IsTakipSistemiWeb.Veritabani
{
    public class IsPersonelOrtak_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<IsPersonelOrtak> Ekle(IsPersonelOrtak data)
        {
            try
            {
                entity.IsPersonelOrtak.Add(data);
                entity.SaveChanges();

                Personel_Veritabani personel_Veritabani = new Personel_Veritabani();
                Personel personel = personel_Veritabani.DetayGetir(data.personel_tc).Veri;

                #region Log Kaydı Yap
                Log logBilgisi = new Log
                {
                    aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                    bilgisayar_ad = Genel_Islemler.GetComputerName(),
                    ip_adres = Genel_Islemler.GetIPAddress(),
                    personel_tc = (HttpContext.Current.Session["kullanici"] as Personel).personel_tc,
                    tarih = DateTime.Now,
                    tur_id = Sabitler.LogTur_KayitEkleme,
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitEkleme, HttpContext.Current.Session["kullanici"] as Personel, "Görev") + " Görevlendirilen Personel: " + personel.ad + " " + personel.soyad + " (T.C.Kimlik No: " + personel.personel_tc + ")"
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion

                return new NIslemSonuc<IsPersonelOrtak>
                {
                    basariliMi = true,
                    Veri = data,
                    mesaj = "Görev Kaydı Tamamlandı!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<IsPersonelOrtak>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Görev Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<List<ViewGorevlendirme>> Listele(int isId)
        {
            try
            {
                List<ViewGorevlendirme> liste = (from u in entity.IsPersonelOrtak
                                                 join p in entity.Personel on u.personel_tc equals p.personel_tc
                                                 join i in entity.Is on u.is_id equals i.is_id
                                                 where u.is_id == isId
                                                 select new ViewGorevlendirme
                                                 {
                                                     aciklama = u.aciklama,
                                                     personelAdSoyad = p.ad + " " + p.soyad,
                                                     baslangic = u.gorev_baslama_tarih.Value,
                                                     bitis = u.gorev_sonlanma_tarih.Value,
                                                     isBaslik = i.baslik,
                                                     kayit_id = u.kayit_id,
                                                     is_id = i.is_id,
                                                     personel_tc = p.personel_tc
                                                 }).ToList();

                #region Log Kaydı Yap
                Log logBilgisi = new Log
                {
                    aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                    bilgisayar_ad = Genel_Islemler.GetComputerName(),
                    ip_adres = Genel_Islemler.GetIPAddress(),
                    personel_tc = (HttpContext.Current.Session["kullanici"] as Personel).personel_tc,
                    tarih = DateTime.Now,
                    tur_id = Sabitler.LogTur_KayitListeleme,
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitListeleme, HttpContext.Current.Session["kullanici"] as Personel, "Görev")
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion

                return new NIslemSonuc<List<ViewGorevlendirme>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewGorevlendirme>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Görev Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Görev Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
    }
}