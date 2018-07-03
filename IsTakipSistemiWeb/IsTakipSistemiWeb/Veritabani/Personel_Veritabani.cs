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
    public class Personel_Veritabani
    {
        // Personel işlemlerinin yapıldığı sınıftır.
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<Personel> GirisYap(string tc, string sifre)
        {
            try
            {
                Personel personel = (from u in entity.Personel where u.personel_tc == tc && u.silindi_mi == false select u).FirstOrDefault();
                if (personel == null)
                {
                    #region Log Kaydı Yap
                    Log logBilgisi = new Log
                    {
                        aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                        bilgisayar_ad = Genel_Islemler.GetComputerName(),
                        ip_adres = Genel_Islemler.GetIPAddress(),
                        personel_tc = null,
                        tarih = DateTime.Now,
                        tur_id = Sabitler.LogTur_BasarisizGirisIslemi,
                        mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_BasarisizGirisIslemi, null, null) + " Girilen Kullanıcı Adı: " + tc
                    };
                    Log_Veritabani.Ekle(logBilgisi);
                    #endregion
                    return new NIslemSonuc<Personel>
                    {
                        basariliMi = false,
                        mesaj = "T.C. Kimlik Numarasına Ait Personel Bulunamadı!"
                    };
                }
                else
                {
                    if (personel.sifre == sifre)
                    {
                        #region Log Kaydı Yap
                        Log logBilgisi = new Log
                        {
                            aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                            bilgisayar_ad = Genel_Islemler.GetComputerName(),
                            ip_adres = Genel_Islemler.GetIPAddress(),
                            personel_tc = personel.personel_tc,
                            tarih = DateTime.Now,
                            tur_id = Sabitler.LogTur_BasariliGirisIslemi,
                            mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_BasariliGirisIslemi, personel, null)
                        };
                        Log_Veritabani.Ekle(logBilgisi);
                        #endregion
                        return new NIslemSonuc<Personel>
                        {
                            basariliMi = true,
                            mesaj = "Giriş Başarılı! Hoşgeldiniz " + personel.ad + " " + personel.soyad,
                            Veri = personel
                        };
                    }
                    else
                    {
                        #region Log Kaydı Yap
                        Log logBilgisi = new Log
                        {
                            aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                            bilgisayar_ad = Genel_Islemler.GetComputerName(),
                            ip_adres = Genel_Islemler.GetIPAddress(),
                            personel_tc = personel.personel_tc,
                            tarih = DateTime.Now,
                            tur_id = Sabitler.LogTur_BasarisizGirisIslemi,
                            mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_BasarisizGirisIslemi, personel, null)
                        };
                        Log_Veritabani.Ekle(logBilgisi);
                        #endregion
                        return new NIslemSonuc<Personel>
                        {
                            basariliMi = false,
                            mesaj = "Hatalı Şifre Girdiniz! Lütfen Tekrar Deneyiniz!"
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<Personel>
                {
                    basariliMi = false,
                    mesaj = "Sistemde Bir Hata Meydana Geldi!",
                    hata = new NHata
                    {
                        aciklama = "Giriş Metodunda Hata Oluştu",
                        mesaj = ex.Message,
                        sinif = "Personel Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }            
        }
        public NIslemSonuc<Personel> DetayGetir(string tc)
        {
            try
            {
                Personel personel = entity.Personel.Where(u => u.personel_tc == tc).FirstOrDefault();
                if (personel != null)
                {
                    return new NIslemSonuc<Personel>
                    {
                        basariliMi = true,
                        Veri = personel
                    };
                }
                else
                {
                    return new NIslemSonuc<Personel>
                    {
                        basariliMi = false,
                        mesaj = "T.C.Kimlik Numarası Sistemde Kayıtlı Değil!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<Personel>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "Kullanici Veritabani",
                        aciklama = "Detay Getir",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<List<ViewPersonel>> TumPersonelleriListele()
        {
            try
            {
                List<ViewPersonel> liste = (from p in entity.Personel
                                            join d in entity.PersonelDepartman on p.departman_id equals d.departman_id
                                            where p.silindi_mi == false
                                            select new ViewPersonel
                                            {
                                                tc = p.personel_tc,
                                                adsoyad = p.ad + " " + p.soyad,
                                                cinsiyet = p.cinsiyet,
                                                departman = d.ad,
                                                mail = p.mail,
                                                telefon = p.telefon,
                                                unvan = p.unvan
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
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitListeleme, HttpContext.Current.Session["kullanici"] as Personel, "Personel")
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion

                return new NIslemSonuc<List<ViewPersonel>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<List<ViewPersonel>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "Personel Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Personel Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<Personel> Ekle(Personel EklenecekPersonel)
        {
            try
            {
                // Aynı TC ye ait personel var mı diye kontrol edilecek
                var sonuc = (from p in entity.Personel where p.personel_tc == EklenecekPersonel.personel_tc select p).ToList();
                if(sonuc.Count > 0)
                {
                    return new NIslemSonuc<Personel>
                    {
                        basariliMi = false,
                        mesaj = "T.C.Kimlik Numarası Sistemde Kayıtlı!"
                    };
                }
                // Yoksa kayıt yap
                else
                {
                    entity.Personel.Add(EklenecekPersonel);
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
                        mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_KayitEkleme, HttpContext.Current.Session["kullanici"] as Personel, "Personel") + " Kaydedilen Personel: " + EklenecekPersonel.ad + " " + EklenecekPersonel.soyad + " (T.C.Kimlik No: " + EklenecekPersonel.personel_tc + ")"
                    };
                    Log_Veritabani.Ekle(logBilgisi);
                    #endregion

                    return new NIslemSonuc<Personel>
                    {
                        basariliMi = true,
                        Veri = EklenecekPersonel,
                        mesaj = "Personel Kaydı Tamamlandı. Varsayılan Şifre: T.C. Kimlik No"
                    };
                }
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<Personel>
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
        public NIslemSonuc<Personel> Guncelle(Personel personel)
        {
            try
            {
                Personel donen_personel = (from p in entity.Personel where p.personel_tc == personel.personel_tc select p).FirstOrDefault();
                donen_personel.soyad = personel.soyad;
                donen_personel.ad = personel.ad;
                donen_personel.adres = personel.adres;
                donen_personel.cinsiyet = personel.cinsiyet;
                donen_personel.departman_id = personel.departman_id;
                donen_personel.dogum_tarih = personel.dogum_tarih;
                donen_personel.ek_mesai_ucret = personel.ek_mesai_ucret;
                donen_personel.fotograf = personel.fotograf;
                donen_personel.guncel_maas = personel.guncel_maas;
                donen_personel.ise_giris_tarih = personel.ise_giris_tarih;
                donen_personel.isten_cikis_tarih = personel.isten_cikis_tarih;
                donen_personel.mail = personel.mail;
                donen_personel.personel_tc = personel.personel_tc;
                donen_personel.sicil_no = personel.sicil_no;
                donen_personel.telefon = personel.telefon;
                donen_personel.tip_id = personel.tip_id;
                donen_personel.unvan = personel.unvan;
                donen_personel.varsayilan_cikis_saat = personel.varsayilan_cikis_saat;
                donen_personel.varsayilan_giris_saat = personel.varsayilan_giris_saat;

                if(personel.sifre != null)
                {
                    donen_personel.sifre = personel.sifre;
                }

                entity.SaveChanges();
                return new NIslemSonuc<Personel>
                {
                    basariliMi = true,
                    mesaj = "Güncelleme İşlemi Tamamlandı!",
                    Veri = personel
                };
            }
            catch(Exception ex)
            {
                return new NIslemSonuc<Personel>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Güncelleme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Personel Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }        
        public NIslemSonuc<Personel> Sil(string personel_tc)
        {
            try 
            {
                Personel donen_personel = (from p in entity.Personel where p.personel_tc == personel_tc select p).FirstOrDefault();
                donen_personel.silindi_mi = true;
                entity.SaveChanges();
                return new NIslemSonuc<Personel>
                {
                    basariliMi = true,
                    mesaj = "Silme İşlemi Tamamlandı!",
                    Veri = donen_personel
                };           
            }
            catch (Exception ex) 
            {
                return new NIslemSonuc<Personel>
                {
                    basariliMi = false,
                    mesaj = "Sistem Hatası!",
                    hata = new NHata
                    {
                        aciklama = "Silme metodunda hata",
                        mesaj = ex.Message,
                        strace = ex.StackTrace,
                        sinif = "Personel Veritabani",
                        tarih = DateTime.Now
                    }
                };
            }
        }
        public NIslemSonuc<List<ViewMesaiKayitlari>> MesaiKayitlariniListele()
        {
            try
            {
                List<ViewMesaiKayitlari> liste = (from m in entity.MesaiKayit
                                                  join p in entity.Personel on m.personel_tc equals p.personel_tc
                                                  where p.silindi_mi == false
                                                  select new ViewMesaiKayitlari
                                                  {
                                                      ad = p.ad,
                                                      cikis_fark = (double?)m.cikis_fark.Value ?? 0,
                                                      cikis_saat = (TimeSpan?)m.cikis_saat.Value ?? TimeSpan.Zero,
                                                      cikis_zaman_farki = (int?)DbFunctions.DiffMinutes(p.varsayilan_cikis_saat.Value, m.cikis_saat.Value).Value ?? 0,
                                                      ek_mesai = 0,
                                                      giris_fark = m.giris_fark.Value,
                                                      giris_saat = m.giris_saat.Value,
                                                      giris_zaman_farki = (int?)DbFunctions.DiffMinutes(p.varsayilan_giris_saat.Value, m.giris_saat.Value).Value ?? 0,
                                                      kayit_id = m.kayit_id,
                                                      personel_tc = p.personel_tc,
                                                      soyad = p.soyad,
                                                      tarih = m.tarih.Value,
                                                      toplam_zaman = (double?)DbFunctions.DiffMinutes(m.giris_saat.Value, m.cikis_saat.Value).Value ?? 0
                                                  }).ToList();

                return new NIslemSonuc<List<ViewMesaiKayitlari>>
                {
                    basariliMi = true,
                    Veri = liste
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<List<ViewMesaiKayitlari>>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        aciklama = "ViewMesaiKayitlari Listeleme Hatası",
                        mesaj = ex.Message,
                        sinif = "Personel Veritabani",
                        strace = ex.StackTrace,
                        tarih = DateTime.Now
                    }
                };
            }
        }
    }
}