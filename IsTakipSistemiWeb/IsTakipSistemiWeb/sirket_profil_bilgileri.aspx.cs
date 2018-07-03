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
    public partial class sirket_profil_bilgileri : System.Web.UI.Page
    {
        SirketProfilBilgileri_Veritabani profilVeritabani = new SirketProfilBilgileri_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BilgileriGetir();
            }
        }

        public void BilgileriGetir()
        {
            divBilgiMesaji.Visible = false;
            var sonuc = profilVeritabani.DetayGetir();
            if(sonuc.basariliMi)
            {
                SirketProfilBilgileri bilgiler = sonuc.Veri;
                TxtAdres.Text = bilgiler.adres;
                TxtBoylam.Text = bilgiler.boylam.ToString();
                TxtEnlem.Text = bilgiler.enlem.ToString();
                TxtFaks.Text = bilgiler.faks;
                TxtMail.Text = bilgiler.mail;
                TxtTelefon.Text = bilgiler.telefon;
                TxtUnvan.Text = bilgiler.unvan;
                TxtWeb.Text = bilgiler.web;
            }
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(2000);

                SirketProfilBilgileri bilgiler = new SirketProfilBilgileri
                {
                    adres = TxtAdres.Text,
                    boylam = Convert.ToDouble(TxtBoylam.Text),
                    enlem = Convert.ToDouble(TxtEnlem.Text),
                    faks = TxtFaks.Text,
                    mail = TxtMail.Text,
                    profilId = 1,
                    telefon = TxtTelefon.Text,
                    unvan = TxtUnvan.Text,
                    web = TxtWeb.Text
                };

                var sonuc = profilVeritabani.Guncelle(bilgiler);
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