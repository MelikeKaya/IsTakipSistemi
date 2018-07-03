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
    public partial class personel_listesi : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
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
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_SayfaGoruntuleme, HttpContext.Current.Session["kullanici"] as Personel, "Personel Listesi")
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion
                TumPersonelleriListele();
            }
        }
        private void TumPersonelleriListele()
        {
            var sonuc = personel_veritabani.TumPersonelleriListele();
            if(sonuc.basariliMi)
            {
                RptPersoneller.DataSource = sonuc.Veri;
                RptPersoneller.DataBind();
            }
        }

        protected void RptPersoneller_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Detay")
            {
                string tc = e.CommandArgument.ToString();
                Response.Redirect("/personel_detay.aspx?tc=" + tc + "");
            }
            else if (e.CommandName == "Sil")
            {
                string tc = e.CommandArgument.ToString();
                var sonuc = personel_veritabani.Sil(tc);
                if(sonuc.basariliMi)
                {
                    TumPersonelleriListele();
                }

               
            }
        }
    }
}