using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Net.Sockets;   

namespace IsTakipSistemiWeb.Yardimci
{
    public class Genel_Islemler
    {
        /// <summary>
        /// Log Kaydı İçin Mesaj Oluşturan Metod
        /// </summary>
        /// <param name="LogTur">Log Türünü Belirtir. Sabitler Sınıfından Log Turlerini Alır.</param>
        /// <param name="personel">İşlem Esnasında Session Nesnesinden Alınan Personeldir.</param>
        /// <param name="ilgiliNesne">İlgili Tabloya Ait Nesnedir. (Firma, Personel, İş vb)</param>
        /// <returns></returns>
        public static string MesajOlustur(int LogTur, Personel personel, string ilgiliNesne)
        {
            string mesaj = "";
            switch (LogTur)
            {
                case Sabitler.LogTur_BasariliGirisIslemi:
                    mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), sisteme başarılı giriş yaptı.";
                    break;
                case Sabitler.LogTur_CikisIslemi:
                    mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), sistemden çıkış yaptı.";
                    break;
                case Sabitler.LogTur_KayitEkleme:
                    mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), sisteme yeni bir " + ilgiliNesne + " kaydetti.";
                    break;
                case Sabitler.LogTur_KayitListeleme:
                    mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), " + ilgiliNesne + " verilerini listeledi.";
                    break;
                case Sabitler.LogTur_SayfaGoruntuleme:
                    mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), " + ilgiliNesne + " sayfasını görüntüledi.";
                    break;
                case Sabitler.LogTur_BasarisizGirisIslemi:
                    if(personel == null)
                    {
                        mesaj = "Sisteme kayıtlı olmayan bir kullanıcı adıyla giriş yapılmaya çalışıldı. Hatalı giriş yapıldı.";
                    }
                    else
                    {
                        mesaj = personel.ad + " " + personel.soyad + " adlı kullanıcı (T.C.Kimlik No: " + personel.personel_tc + "), sisteme hatalı giriş yaptı.";
                    }                    
                    break;
                default:
                    break;
            }
            return mesaj;
        }

        /// <summary>
        /// Log eklenirken işlemi yapan kullanıcının IP adresinin alınmasını sağlayan metottur.
        /// </summary>
        /// <returns>Kullanıcının IP Adresi</returns>
        public static string GetIPAddress()
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;

            if (ipAddress.Length < 5)
            {
                ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == AddressFamily.InterNetwork).First().ToString();
            }

            return ipAddress;
        }

        /// <summary>
        /// Log eklenirken işlemi yapan kullanıcının bilgisayar adının alınmasını sağlayan metottur
        /// </summary>
        /// <param name="req">Talep Eden HTTP Request'i</param>
        /// <returns>Kullanıcının Bilgisayar Adı</returns>
        public static string GetComputerName()
        {
            string machineName = "";
            try
            {
                machineName = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_host"]).HostName.ToString();
                if (machineName.Length < 1)
                {
                    machineName = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName.ToString();
                }
                return machineName;
            }
            catch
            {
                machineName = "Bilgisayar Adı Alınamadı! IP Adresi: " + GetIPAddress();
                return machineName;
            }
        }
    }
}