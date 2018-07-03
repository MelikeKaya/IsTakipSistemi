using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Yardimci;

namespace IsTakipSistemiWeb.Veritabani
{
    public class Firma_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<Firma> DetayGetir(int id)
        {
            try
            {
                Firma firma = entity.Firma.Where(u => u.firma_id == id).FirstOrDefault();
                if (firma != null)
                {
                    return new NIslemSonuc<Firma>
                    {
                        basariliMi = true,
                        Veri = firma
                    };
                }
                else
                {
                    return new NIslemSonuc<Firma>
                    {
                        basariliMi = false,
                        mesaj = "Firma Kayıtlı Değil!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Firma>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "Firma Veritabani",
                        aciklama = "Detay Getir",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<List<ViewFirma>> TumFirmalariListele()
        {
            try
            {
                List<ViewFirma> liste = (from f in entity.Firma
                                            join d in entity.FirmaDurum on f.durum_id equals d.durum_id
                                            where f.silindi_mi == false
                                            select new ViewFirma
                                            {
                                                cari_kod = f.cari_kod,
                                                durum = d.ad,
                                                firma_id = f.firma_id,
                                                sgk_no = f.sgk_no,
                                                mail = f.mail,
                                                telefon = f.telefon,
                                                unvan = f.unvan,
                                                arkaplan_rengi = d.arkaplan_rengi
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
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitListeleme, HttpContext.Current.Session["kullanici"] as Personel, "Firma")
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion

                return new NIslemSonuc<List<ViewFirma>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewFirma>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Firma Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Firma Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<Firma> Ekle(Firma EklenecekFirma)
        {
            try
            {
                entity.Firma.Add(EklenecekFirma);
                entity.SaveChanges();
                #region Log Kaydı Yap
                Log logBilgisi = new Log
                {
                    aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                    bilgisayar_ad = Genel_Islemler.GetComputerName(),
                    ip_adres = Genel_Islemler.GetIPAddress(),
                    personel_tc = (HttpContext.Current.Session["kullanici"] as Personel).personel_tc,
                    tarih = DateTime.Now,
                    tur_id = Sabitler.LogTur_KayitEkleme,
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitEkleme, HttpContext.Current.Session["kullanici"] as Personel, "Firma") + " Kaydedilen Veri: " + EklenecekFirma.unvan + " (Firma ID: " + EklenecekFirma.firma_id + ")",
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion
                return new NIslemSonuc<Firma>
                {
                    basariliMi = true,
                    Veri = EklenecekFirma,
                    mesaj = "Firma Kaydı Tamamlandı!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Firma>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Ekleme Metodunda Hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Personel Veritabani",
                        tarih = DateTime.Now
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<Firma> Guncelle(Firma firma)
        {
            try
            {
                Firma donen_firma = (from f in entity.Firma where f.firma_id == firma.firma_id select f).FirstOrDefault();
                donen_firma.adres = firma.adres;
                donen_firma.boylam = firma.boylam;
                donen_firma.cari_kod = firma.cari_kod;
                donen_firma.durum_id = firma.durum_id;
                donen_firma.enlem = firma.enlem;
                donen_firma.kisa_ad = firma.kisa_ad;
                donen_firma.mail = firma.mail;
                donen_firma.sgk_no = firma.sgk_no;
                donen_firma.silindi_mi = firma.silindi_mi;
                donen_firma.telefon = firma.telefon;
                donen_firma.unvan = firma.unvan;
                donen_firma.vergi_daire = firma.vergi_daire;
                donen_firma.vergi_no = firma.vergi_no;

                entity.SaveChanges();
                return new NIslemSonuc<Firma>
                {
                    basariliMi = true,
                    mesaj = "Güncelleme İşlemi Tamamlandı!",
                    Veri = donen_firma
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Firma>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Güncelleme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Firma Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<Firma> Sil(int id)
        {
            try
            {
                Firma donen_firma = (from f in entity.Firma where f.firma_id == id select f).FirstOrDefault();
                donen_firma.silindi_mi = true;
                entity.SaveChanges();
                return new NIslemSonuc<Firma>
                {
                    basariliMi = true,
                    mesaj = "Silme İşlemi Tamamlandı!",
                    Veri = donen_firma
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Firma>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Silme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Firma Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<string> GetirAnaSayfaSayilar()
        {
            try
            {
                string str = "";

                int aktifFirmaSayisi = entity.Firma.Where(f=>f.durum_id == 1 && f.silindi_mi == false).ToList().Count;
                int pasifFirmaSayisi = entity.Firma.Where(f => f.durum_id == 2 && f.silindi_mi == false).ToList().Count;
                int teklifFirmaSayisi = entity.Firma.Where(f => f.durum_id == 3 && f.silindi_mi == false).ToList().Count;
                int toplamFirmaSayisi = entity.Firma.Where(f => f.silindi_mi == false).ToList().Count;

                int aktifPersonelSayisi = entity.Personel.Where(f => f.silindi_mi == false).ToList().Count;
                int bitenIsSayisi = entity.Is.Where(f => f.durum_id == 7 && f.silindi_mi == false).ToList().Count;
                int pasifIsSayisi = entity.Is.Where(f => f.silindi_mi == true).ToList().Count;
                int toplamIsSayisi = entity.Is.Where(f => f.silindi_mi == false).ToList().Count;

                str = aktifFirmaSayisi.ToString() + ":" + pasifFirmaSayisi.ToString() + ":" + teklifFirmaSayisi.ToString() + ":" + toplamFirmaSayisi.ToString() + ":" + aktifPersonelSayisi.ToString() + ":" + bitenIsSayisi.ToString() + ":" + pasifIsSayisi.ToString() + ":" + toplamIsSayisi.ToString();

                return new NIslemSonuc<string>
                {
                    basariliMi = true,
                    Veri = str
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<string>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "Firma Veritabani",
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