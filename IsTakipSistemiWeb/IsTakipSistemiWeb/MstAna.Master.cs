using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Yardimci;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class MstAna : System.Web.UI.MasterPage
    {
        Bildirim_Veritabani bildirim_veritabani = new Bildirim_Veritabani();
        RolHak_Veritabani rolHak_veritabani = new RolHak_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["kullanici"] == null)
                {
                    Response.Redirect("/login.aspx");
                }
                else
                {
                    Personel online_personel = Session["kullanici"] as Personel;
                    LblAdSoyad.Text = online_personel.ad + " " + online_personel.soyad;

                    #region Bildirimleri Getir
                    Ziyaret_Veritabani ziyaret_Veritabani = new Ziyaret_Veritabani();
                    List<ViewZiyaret> ziyaretListesi = ziyaret_Veritabani.Listele().Veri.Where(z => z.goruldu_mu == false).ToList();
                    List<string> bildirimlerListe = new List<string>();
                    foreach(var item in ziyaretListesi)
                    {
                        if(item.girisUzaklik > 3000)
                        {
                            string str = item.personelAdSoyad + ", " + item.firma + " isimli firmaya 5 km ve üzeri uzaklıkta check-in yaptı!";
                            bildirimlerListe.Add(str);
                        }
                    }

                    int gorulmeyenBildirimSayisi = bildirimlerListe.Count();

                    if(gorulmeyenBildirimSayisi > 0)
                    {
                        spBildirimBaslik.InnerHtml = gorulmeyenBildirimSayisi.ToString() + " Yeni Bildirim";
                        spBildirimSayi.InnerHtml = gorulmeyenBildirimSayisi.ToString();
                    }
                    else
                    {
                        spBildirimBaslik.InnerHtml = "Yeni Bildiriminiz Yok";
                        spBildirimSayi.InnerHtml = "";
                    }

                    RptBildirimler.DataSource = bildirimlerListe;
                    RptBildirimler.DataBind();
                    #endregion

                    #region Yetkilendirme

                    //Önce Linkleri Görünmez Yap
                    foreach(Control item in pnlMenu.Controls)
                    {
                        if(item is HtmlAnchor)
                        {
                            item.Visible = false;
                        }
                    }
                    //Önce Linkleri Görünmez Yap

                    List<ViewRolHak> rolHakListesi = rolHak_veritabani.Listele().Veri;
                    List<Tuple<string, string>> linkListesi = (from rh in rolHakListesi where rh.rol_id == online_personel.kullanici_rol_id select Tuple.Create(rh.link_id, rh.ust_link_id)).ToList();
                    for(int i=0; i< linkListesi.Count; i++)
                    {
                        string id = linkListesi[i].Item1;
                        string ust_id = linkListesi[i].Item2;
                        HtmlAnchor link = (HtmlAnchor)FindControl(id);
                        HtmlAnchor ust_link = (HtmlAnchor)FindControl(ust_id);
                        link.Visible = true;
                        ust_link.Visible = true;
                    }
                    #endregion
                }
            }
        }

        protected void BtnCikisYap_Click(object sender, EventArgs e)
        {
            #region Log Kaydı Yap
            Log logBilgisi = new Log
            {
                aktif_sayfa = HttpContext.Current.Request.Url.AbsoluteUri,
                bilgisayar_ad = Genel_Islemler.GetComputerName(),
                ip_adres = Genel_Islemler.GetIPAddress(),
                personel_tc = (HttpContext.Current.Session["kullanici"] as Personel).personel_tc,
                tarih = DateTime.Now,
                tur_id = Sabitler.LogTur_CikisIslemi,
                mesaj = Genel_Islemler.MesajOlustur(Sabitler.LogTur_CikisIslemi, HttpContext.Current.Session["kullanici"] as Personel, null)
            };
            Log_Veritabani.Ekle(logBilgisi);
            #endregion
            Session["kullanici"] = null;
            Response.Redirect("/index.aspx");
        }
    }
}