using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Yardimci
{
    public class Hesaplama
    {
        public int YasHesapla(DateTime dogum_tarih)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dogum_tarih.Year;
            if (dogum_tarih > now.AddYears(-age)) age--;
            return age;
        }
    }
}