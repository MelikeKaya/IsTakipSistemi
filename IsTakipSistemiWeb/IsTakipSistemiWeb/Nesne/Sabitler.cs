using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class Sabitler
    {
        #region Bildirim Türleri Sabitleri
        public const int BildirimTur_PersonelKaydi = 1;
        public const int BildirimTur_PersonelBilgiGuncelleme = 2;
        public const int BildirimTur_GorevAtamasi = 3;
        #endregion

        #region Log Türleri Sabitleri
        public const int LogTur_KayitEkleme = 1;
        public const int LogTur_KayitSilme = 2;
        public const int LogTur_KayitListeleme = 3;
        public const int LogTur_KayitGuncelleme = 4;
        public const int LogTur_SayfaGoruntuleme = 5;
        public const int LogTur_BasariliGirisIslemi = 6;
        public const int LogTur_BasarisizGirisIslemi = 7;
        public const int LogTur_CikisIslemi = 8;
        #endregion
    }
}