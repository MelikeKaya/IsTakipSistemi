using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Yardimci;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class index : System.Web.UI.Page
    {
        Firma_Veritabani firma_Veritabani = new Firma_Veritabani();
        Personel_Veritabani personel_Veritabani = new Personel_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["kullanici"] != null)
                {
                    #region Log Kaydı Yap
                    Log logBilgisi = new Log
                    {
                        aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                        bilgisayar_ad = Genel_Islemler.GetComputerName(),
                        ip_adres = Genel_Islemler.GetIPAddress(),
                        personel_tc = (HttpContext.Current.Session["kullanici"] as Personel).personel_tc,
                        tarih = DateTime.Now,
                        tur_id = Sabitler.LogTur_SayfaGoruntuleme,
                        mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_SayfaGoruntuleme, HttpContext.Current.Session["kullanici"] as Personel, "Anasayfa")
                    };
                    Log_Veritabani.Ekle(logBilgisi);
                    #endregion

                    string firmaRaporSonuc = firma_Veritabani.GetirAnaSayfaSayilar().Veri;
                    string[] partsFirma = firmaRaporSonuc.Split(':');
                    spAktifFirma.Attributes.Add("data-value", partsFirma[0]);
                    spPasifFirma.Attributes.Add("data-value", partsFirma[1]);
                    spTeklifFirma.Attributes.Add("data-value", partsFirma[2]);
                    spToplamFirma.Attributes.Add("data-value", partsFirma[3]);
                    spPersonel.Attributes.Add("data-value", partsFirma[4]);
                    spBitenIs.Attributes.Add("data-value", partsFirma[5]);
                    spPasifIs.Attributes.Add("data-value", partsFirma[6]);
                    spToplamIs.Attributes.Add("data-value", partsFirma[7]);
                }
            }
        }
    }
}