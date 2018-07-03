using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb.Veritabani
{
    public class MailAyar_Veritabani
    {
        dbIsTakipEntities entity = new dbIsTakipEntities();

        public NIslemSonuc<MailAyar> DetayGetir()
        {
            try
            {
                MailAyar mailayar = entity.MailAyar.FirstOrDefault();
                return new NIslemSonuc<MailAyar>
                {
                    basariliMi = true,
                    Veri = mailayar
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<MailAyar>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "MailAyar Veritabani",
                        aciklama = "Detay Getir",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
        public NIslemSonuc<MailAyar> Guncelle(MailAyar yeniAyar)
        {
            try
            {
                MailAyar mailayar = entity.MailAyar.FirstOrDefault();

                mailayar.host = yeniAyar.host;
                mailayar.mail = yeniAyar.mail;
                mailayar.port = yeniAyar.port;
                mailayar.ssl = yeniAyar.ssl;
                mailayar.sifre = yeniAyar.sifre;

                entity.SaveChanges();

                return new NIslemSonuc<MailAyar>
                {
                    basariliMi = true,
                    Veri = mailayar,
                    mesaj = "Mail Ayarları Başarıyla Güncellendi!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<MailAyar>
                {
                    basariliMi = false,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        sinif = "MailAyar Veritabani",
                        aciklama = "Güncelle metodunda hata",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    },
                    mesaj = "Sistemde Bir Hata Oluştu!"
                };
            }
        }
    }
}