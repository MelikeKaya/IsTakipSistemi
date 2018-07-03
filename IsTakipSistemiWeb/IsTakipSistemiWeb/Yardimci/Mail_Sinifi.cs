using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Nesne;
using System.Net;
using System.Net.Mail;
using IsTakipSistemiWeb.Entity;

namespace IsTakipSistemiWeb.Yardimci
{
    public class Mail_Sinifi
    {
        public static string gorunecek_isim = "İş Takip Sistemi";

        public NIslemSonuc<bool> MailGonder(string konu, string alici, string icerik, MailAyar ayarlar)
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = int.Parse(ayarlar.port.ToString());
                sc.Host = ayarlar.host;

                if(ayarlar.ssl == true)
                {
                    sc.EnableSsl = true;
                }

                sc.Credentials = new NetworkCredential(ayarlar.mail, ayarlar.sifre);

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ayarlar.mail, gorunecek_isim);

                mail.To.Add(alici);

                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;

                sc.Send(mail);

                return new NIslemSonuc<bool>
                {
                    basariliMi = true,
                    mesaj = "Sistemde Kayıtlı Olan E-Posta Adresine Şifreniz Gönderilmiştir!"
                };
            }
            catch (Exception ex)
            {
                return new NIslemSonuc<bool>
                {
                    basariliMi = false,
                    mesaj = ex.Message,
                    hata = new NHata
                    {
                        mesaj = ex.Message,
                        aciklama = "Mail Gönder",
                        sinif = "Mail Sinifi",
                        tarih = DateTime.Now,
                        strace = ex.StackTrace
                    }
                };
            }
        }
    }
}