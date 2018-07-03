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
    public partial class mail_ayarlari : System.Web.UI.Page
    {
        MailAyar_Veritabani mailayar_veritabani = new MailAyar_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BilgileriGetir();
                divBilgiMesaji.Visible = false;
            }
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;

            if(TxtSifre.Text == TxtSifreTekrar.Text)
            {
                try
                {
                    System.Threading.Thread.Sleep(3000);

                    bool ssl_durum = true;
                    if (RdKapaliSsl.Checked)
                    {
                        ssl_durum = false;
                    }

                    MailAyar ayarlar = new MailAyar
                    {
                        host = TxtHost.Text,
                        mail = TxtMail.Text,
                        port = int.Parse(TxtPort.Text),
                        sifre = TxtSifre.Text,
                        ssl = ssl_durum
                    };

                    var sonuc = mailayar_veritabani.Guncelle(ayarlar);

                    if (sonuc.basariliMi)
                    {
                        divBilgiMesaji.Attributes.Add("class", "alert alert-success");
                        BilgileriGetir();
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

                    divBilgiMesaji.InnerText = sonuc.mesaj;
                }
                catch (Exception ex)
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                    divBilgiMesaji.InnerText = "Lütfen Girdiğiniz Bilgileri Kontrol Ediniz! Formata Uygun Veriler Giriniz..";
                    //Hatayı Kaydet
                } 
            }
            else
            {
                divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                divBilgiMesaji.InnerText = "Şifreleriniz Uyuşmuyor!";
            }              
        }

        private void BilgileriGetir()
        {
            var sonuc = mailayar_veritabani.DetayGetir();
            if (sonuc.basariliMi)
            {
                TxtHost.Text = sonuc.Veri.host;
                TxtMail.Text = sonuc.Veri.mail;
                TxtPort.Text = sonuc.Veri.port.ToString();
                TxtSifre.Text = sonuc.Veri.sifre;
                TxtSifreTekrar.Text = sonuc.Veri.sifre;
            }
        }
    }
}