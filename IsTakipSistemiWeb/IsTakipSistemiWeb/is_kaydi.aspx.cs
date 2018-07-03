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
    public partial class is_kaydi : System.Web.UI.Page
    {
        Firma_Veritabani firmaVeritabani = new Firma_Veritabani();
        IsDurum_Veritabani isDurumVeritabani = new IsDurum_Veritabani();
        IsTur_Veritabani isTurVeritabani = new IsTur_Veritabani();
        Is_Veritabani isVeritabani = new Is_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonucIsTur = isTurVeritabani.Listele();
                var sonucIsDurum = isDurumVeritabani.Listele();
                var sonucFirma = firmaVeritabani.TumFirmalariListele();

                DrpDurum.DataSource = sonucIsDurum.Veri;
                DrpDurum.DataTextField = "ad";
                DrpDurum.DataValueField = "durum_id";
                DrpDurum.DataBind();

                DrpTur.DataSource = sonucIsTur.Veri;
                DrpTur.DataTextField = "ad";
                DrpTur.DataValueField = "tur_id";
                DrpTur.DataBind();

                DrpFirma.DataSource = sonucFirma.Veri;
                DrpFirma.DataTextField = "unvan";
                DrpFirma.DataValueField = "firma_id";
                DrpFirma.DataBind();

                divBilgiMesaji.Visible = false;
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(3000);

                Is data = new Is
                {
                    aciklama = TxtAciklama.Text,
                    alinan_ucret = Convert.ToDouble(TxtAlinan.Text),
                    aylik_ucret = Convert.ToDouble(TxtAylik.Text),
                    baslik = TxtBaslik.Text,
                    durum_id = int.Parse(DrpDurum.SelectedValue),
                    firma_id = int.Parse(DrpFirma.SelectedValue),
                    kayit_tarih = Convert.ToDateTime(TxtKayitTarih.Text),
                    silindi_mi = false,
                    yillik_ucret = Convert.ToDouble(TxtYillik.Text),
                    ucret = Convert.ToDouble(TxtAlinacak.Text),
                    tur_id = int.Parse(DrpTur.SelectedValue),
                    sure = int.Parse(TxtGun.Text),
                    sozlesme = "Yüklenmedi.."
                };

                var sonuc = isVeritabani.Ekle(data);
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