using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class ziyaret_detay : System.Web.UI.Page
    {
        Ziyaret_Veritabani ziyaretVeritabani = new Ziyaret_Veritabani();
        Firma_Veritabani firmaVeritabani = new Firma_Veritabani();
        Personel_Veritabani personelVeritabani = new Personel_Veritabani();
        FirmaDurum_Veritabani firmaDurumVeritabani = new FirmaDurum_Veritabani();
        PersonelTip_Veritabani personelTipVeritabani = new PersonelTip_Veritabani();
        ZiyaretTur_Veritabani ziyaretTurVeritabani = new ZiyaretTur_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ziyaret_id = int.Parse(Request.QueryString["id"].ToString());

                #region FirmaDurumlari -> DropDown
                DrpFirmaDurum.DataSource = firmaDurumVeritabani.Listele().Veri;
                DrpFirmaDurum.DataTextField = "ad";
                DrpFirmaDurum.DataValueField = "durum_id";
                DrpFirmaDurum.DataBind();
                #endregion

                #region PersonelTipleri -> DropDown
                DrpPersonelGorev.DataSource = personelTipVeritabani.Listele().Veri;
                DrpPersonelGorev.DataTextField = "ad";
                DrpPersonelGorev.DataValueField = "tip_id";
                DrpPersonelGorev.DataBind();
                #endregion

                #region ZiyaretTurleri -> DropDown
                DrpZiyaretTur.DataSource = ziyaretTurVeritabani.Listele().Veri;
                DrpZiyaretTur.DataTextField = "ad";
                DrpZiyaretTur.DataValueField = "tur_id";
                DrpZiyaretTur.DataBind();
                #endregion

                #region Ziyaret Bilgileri Alınıyor.
                Ziyaret ziyaret = ziyaretVeritabani.DetayGetir(ziyaret_id).Veri;
                TxtZiyaretAciklama.Text = ziyaret.aciklama;
                TxtGirisTarihi.Text = ziyaret.giris_tarih.ToString();
                TxtCikisTarihi.Text = ziyaret.cikis_tarih.ToString();
                DrpZiyaretTur.SelectedValue = ziyaret.tur_id.ToString();
                #endregion

                #region Firma Bilgileri Alınıyor.
                Firma firma = firmaVeritabani.DetayGetir(ziyaret.firma_id.Value).Veri;
                TxtFirmaAdres.Text = firma.adres;
                TxtFirmaSgk.Text = firma.sgk_no;
                TxtFirmaTelefon.Text = firma.telefon;
                TxtFirmaUnvan.Text = firma.unvan;
                DrpFirmaDurum.SelectedValue = firma.durum_id.ToString();
                #endregion

                #region Personel Bilgileri Alınıyor.
                Personel personel = personelVeritabani.DetayGetir(ziyaret.personel_tc).Veri;
                TxtPersonelAdSoyad.Text = personel.ad + " " + personel.soyad;
                TxtPersonelMail.Text = personel.mail;
                TxtPersonelTC.Text = personel.personel_tc;
                TxtPersonelTelefon.Text = personel.telefon;
                DrpPersonelGorev.SelectedValue = personel.tip_id.ToString();
                #endregion
            }
        }
    }
}