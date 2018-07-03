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
    public partial class personel_detay : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();
        PersonelDepartman_Veritabani departman_veritabani = new PersonelDepartman_Veritabani();
        PersonelTip_Veritabani tip_veritabani = new PersonelTip_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BilgileriGetir();
            }
        }

        private void BilgileriGetir()
        {
            TxtTc.Enabled = false;

            var sonucTip = tip_veritabani.Listele();
            var sonucDepartman = departman_veritabani.Listele();

            DrpTip.DataSource = sonucTip.Veri;
            DrpTip.DataTextField = "ad";
            DrpTip.DataValueField = "tip_id";
            DrpTip.DataBind();

            DrpDepartman.DataSource = sonucDepartman.Veri;
            DrpDepartman.DataTextField = "ad";
            DrpDepartman.DataValueField = "departman_id";
            DrpDepartman.DataBind();

            divBilgiMesaji.Visible = false;

            string tc = Request.QueryString["tc"].ToString();
            var sonuc = personel_veritabani.DetayGetir(tc);
            if (sonuc.basariliMi)
            {
                Personel personel = sonuc.Veri;
                spanAdSoyad.InnerText = personel.ad + " " + personel.soyad;
                TxtAd.Text = personel.ad;
                TxtSoyad.Text = personel.soyad;
                TxtSicil.Text = personel.sicil_no;
                TxtTc.Text = personel.personel_tc;
                TxtAdres.Text = personel.adres;
                TxtEkMesaiUcret.Text = personel.ek_mesai_ucret.ToString();
                TxtMaas.Text = personel.guncel_maas.ToString();
                TxtMail.Text = personel.mail;
                TxtTelefon.Text = personel.telefon;
                TxtUnvan.Text = personel.unvan;
                DateDogum.Value = Convert.ToDateTime(personel.dogum_tarih).ToString("yyyy-MM-dd");
                DateIseGiris.Value = Convert.ToDateTime(personel.ise_giris_tarih).ToString("yyyy-MM-dd");
                TimeGiris.Value = personel.varsayilan_giris_saat.ToString();
                TimeCikis.Value = personel.varsayilan_cikis_saat.ToString();
                if (personel.cinsiyet == "Erkek")
                {
                    RdErkek.Checked = true;
                }
                else
                {
                    RdKadin.Checked = true;
                }
                DrpDepartman.SelectedValue = personel.departman_id.ToString();
                DrpTip.SelectedValue = personel.tip_id.ToString();
            }                
        }

        protected void BtnGuncelle_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(2000);

                string cinsiyet = "Erkek";
                if (RdKadin.Checked)
                {
                    cinsiyet = "Kadın";
                }

                Personel personel = new Personel
                {
                    ad = TxtAd.Text,
                    adres = TxtAdres.Text,
                    cinsiyet = cinsiyet,
                    departman_id = int.Parse(DrpDepartman.SelectedValue),
                    dogum_tarih = Convert.ToDateTime(DateDogum.Value),
                    ek_mesai_ucret = Convert.ToDouble(TxtEkMesaiUcret.Text),
                    fotograf = TxtTc.Text,
                    guncel_maas = Convert.ToDouble(TxtMaas.Text),
                    ise_giris_tarih = Convert.ToDateTime(DateIseGiris.Value),
                    mail = TxtMail.Text,
                    personel_tc = TxtTc.Text,
                    sicil_no = TxtSicil.Text,
                    silindi_mi = false,
                    soyad = TxtSoyad.Text,
                    telefon = TxtTelefon.Text,
                    tip_id = int.Parse(DrpTip.SelectedValue),
                    unvan = TxtUnvan.Text,
                    varsayilan_giris_saat = Convert.ToDateTime(TimeGiris.Value).TimeOfDay,
                    varsayilan_cikis_saat = Convert.ToDateTime(TimeCikis.Value).TimeOfDay,
                };

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