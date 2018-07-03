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
    public partial class firma_listesi : System.Web.UI.Page
    {
        Firma_Veritabani firma_veritabani = new Firma_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                    mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_SayfaGoruntuleme, HttpContext.Current.Session["kullanici"] as Personel, "Firma Listesi")
                };
                Log_Veritabani.Ekle(logBilgisi);
                #endregion
                TumFirmalariListele();
            }
        }

        private void TumFirmalariListele()
        {
            var sonuc = firma_veritabani.TumFirmalariListele();
            if (sonuc.basariliMi)
            {
                RptFirmalar.DataSource = sonuc.Veri;
                RptFirmalar.DataBind();
            }
            else
            {
                if(sonuc.hata != null)
                {
                    //Hata Kaydı
                }
            }
        }

        protected void RptFirmalar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Detay")
            {               
                Response.Redirect("/firma_detay.aspx?id=" + id + "");
            }
            else if (e.CommandName == "Sil")
            {
                var sonuc = firma_veritabani.Sil(id);
                if (sonuc.basariliMi)
                {
                    TumFirmalariListele();
                }
                else
                {
                    if (sonuc.hata != null)
                    {
                        //Hata Kaydı
                    }
                }
            }
        }
    }
}