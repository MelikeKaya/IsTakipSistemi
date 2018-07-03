using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Entity;

namespace IsTakipSistemiWeb
{
    public partial class ziyaret_kaydi : System.Web.UI.Page
    {
        Ziyaret_Veritabani ziyaretVeritabani = new Ziyaret_Veritabani();
        ZiyaretTur_Veritabani ziyaretTurVeritabani = new ZiyaretTur_Veritabani();
        Firma_Veritabani firmaVeritabani = new Firma_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                divBilgiMesaji.Visible = false;

                var sonucTur = ziyaretTurVeritabani.Listele();
                DrpTur.DataSource = sonucTur.Veri;
                DrpTur.DataTextField = "ad";
                DrpTur.DataValueField = "tur_id";
                DrpTur.DataBind();

                var sonucFirma = firmaVeritabani.TumFirmalariListele();
                DrpFirma.DataSource = sonucFirma.Veri;
                DrpFirma.DataTextField = "unvan";
                DrpFirma.DataValueField = "firma_id";
                DrpFirma.DataBind();
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(3000);

                Ziyaret ziyaret = new Ziyaret
                {
                    aciklama = TxtAciklama.Text,
                    boylam = 0.0,
                    enlem = 0.0,
                    cikis_tarih = DateTime.Now,
                    firma_id = int.Parse(DrpFirma.SelectedValue),
                    giris_tarih = DateTime.Now,
                    konum = "Bilinmiyor",
                    personel_tc = (Session["kullanici"] as Personel).personel_tc,
                    tur_id = int.Parse(DrpTur.SelectedValue)
                };

                var sonuc = ziyaretVeritabani.Ekle(ziyaret);
                divBilgiMesaji.InnerText = sonuc.mesaj;

                if (sonuc.basariliMi)
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-success");
                }
                else
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                    if (sonuc.hata != null)
                    {
                        //HATA KAYDI YAP SİSTEM HATASI VAR
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                divBilgiMesaji.InnerText = "Lütfen Girdiğiniz Bilgileri Kontrol Ediniz! Formata Uygun Veriler Giriniz..";
                //Hatayı Kaydet
            }
        }
    }
}