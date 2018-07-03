using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb
{
    public partial class profil_sayfam : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();
        Hata_Veritabani hata_veritabani = new Hata_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BilgileriGetir();
            }
        }

        private void BilgileriGetir()
        {
            divBilgiMesaji.Visible = false;

            Personel personel = Session["kullanici"] as Personel;
            spanAdSoyad.InnerText = personel.ad + " " + personel.soyad;
            TxtTc.Text = personel.personel_tc;
            TxtAdres.Text = personel.adres;
            TxtMail.Text = personel.mail;
            TxtTelefon.Text = personel.telefon;
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Personel personel = Session["kullanici"] as Personel;
            divBilgiMesaji.Visible = true;
            string sifre = personel.sifre;
            try
            {
                System.Threading.Thread.Sleep(2000);

                if (TxtSifre.Text != "" && (TxtSifre.Text == TxtSifreTekrar.Text))
                {
                    sifre = TxtSifre.Text;
                }

                personel.adres = TxtAdres.Text;
                personel.mail = TxtMail.Text;
                personel.sifre = sifre;
                personel.telefon = TxtTelefon.Text;

                var sonuc = personel_veritabani.Guncelle(personel);
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
                        //HATA KAYDI
                        NHata nesne_hata = sonuc.hata;
                        Hata hata = new Hata
                        {
                            aciklama = nesne_hata.aciklama,
                            mesaj = nesne_hata.mesaj,
                            sinif = nesne_hata.sinif,
                            strace = nesne_hata.strace,
                            tarih = nesne_hata.tarih
                        };
                        var Hata_Kaydi = hata_veritabani.Ekle(hata);
                        //HATA KAYDI
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