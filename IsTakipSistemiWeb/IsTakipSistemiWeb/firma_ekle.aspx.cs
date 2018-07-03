using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Yardimci;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb
{
    public partial class firma_ekle : System.Web.UI.Page
    {
        Firma_Veritabani firma_veritabani = new Firma_Veritabani();
        FirmaDurum_Veritabani firmadurum_veritabani = new FirmaDurum_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sonucDurum = firmadurum_veritabani.Listele();

                DrpDurum.DataSource = sonucDurum.Veri;
                DrpDurum.DataTextField = "ad";
                DrpDurum.DataValueField = "durum_id";
                DrpDurum.DataBind();

                divBilgiMesaji.Visible = false;
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(3000);

                Firma firma = new Firma
                {
                    boylam = Convert.ToDouble(TxtBoylam.Text),
                    adres = TxtAdres.Text,
                    cari_kod = TxtCariKod.Text,
                    durum_id = int.Parse(DrpDurum.SelectedValue),
                    enlem = Convert.ToDouble(TxtEnlem.Text),
                    kisa_ad = TxtKisaAd.Text,
                    sgk_no = TxtSgkNo.Text,
                    vergi_daire = TxtVergiDaire.Text,
                    vergi_no = TxtVergiNo.Text,
                    telefon = TxtTelefon.Text,
                    unvan = TxtUnvan.Text,
                    mail = TxtMail.Text,
                    silindi_mi = false
                };

                var sonuc = firma_veritabani.Ekle(firma);
                divBilgiMesaji.InnerText = sonuc.mesaj;

                if (sonuc.basariliMi)
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-success");
                    Temizle();
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

        public void Temizle()
        {
            TxtAdres.Text = "";
            TxtBoylam.Text = "";
            TxtCariKod.Text = "";
            TxtEnlem.Text = "";
            TxtKisaAd.Text = "";
            TxtMail.Text = "";
            TxtSgkNo.Text = "";
            TxtTelefon.Text = "";
            TxtUnvan.Text = "";
            TxtVergiDaire.Text = "";
            TxtVergiNo.Text = "";
        }

    }
}