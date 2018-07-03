using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Yardimci
{
    public class String_Islemleri
    {
        public string BenzersizAdUret()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string DakikayiSaatOlarakYazdir(int dakika)
        {
            string str = "";
            double dakika_ = Convert.ToDouble(dakika);
            int saat = (int)dakika_ / 60;
            if(saat > 0)
            {
                str = str + saat.ToString() + " Saat ";
            }
            int zamanSaat = saat * 60;
            int kalanDakika = dakika - zamanSaat;
            if(kalanDakika > 0)
            {
                str = str + kalanDakika.ToString() + " Dakika ";
            }
            return str;
        }
        public static string ZamanFarkiGetir(DateTime tarih1, DateTime tarih2)
        {
            TimeSpan fark = tarih2 - tarih1;
            if(fark.Minutes < 1)
            {
                return fark.Seconds.ToString() + " saniye";
            }
            else if(fark.Hours < 1)
            {
                return fark.Minutes.ToString() + " dakika";
            }
            else if(fark.Days < 1)
            {
                return fark.Hours.ToString() + " saat";
            }
            else
            {
                return fark.Days.ToString() + " gün";
            }
        }
    }
}