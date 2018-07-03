using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb
{
    public partial class personel_ekle : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();
        PersonelDepartman_Veritabani departman_veritabani = new PersonelDepartman_Veritabani();
        PersonelTip_Veritabani tip_veritabani = new PersonelTip_Veritabani();
        Bildirim_Veritabani bildirim_veritabani = new Bildirim_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
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
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            Personel online_personel = Session["kullanici"] as Personel;
            divBilgiMesaji.Visible = true;
            try
            {
                System.Threading.Thread.Sleep(3000);

                string cinsiyet = "Erkek";
                if(RdKadin.Checked)
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
                    sifre = TxtTc.Text,
                    silindi_mi = false,
                    soyad = TxtSoyad.Text,
                    telefon = TxtTelefon.Text,
                    tip_id = int.Parse(DrpTip.SelectedValue),
                    unvan = TxtUnvan.Text,
                    varsayilan_giris_saat = Convert.ToDateTime(TimeGiris.Value).TimeOfDay,
                    varsayilan_cikis_saat = Convert.ToDateTime(TimeCikis.Value).TimeOfDay
                };

                var sonuc = personel_veritabani.Ekle(personel);
                divBilgiMesaji.InnerText = sonuc.mesaj;

                if (sonuc.basariliMi)
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-success");
                    #region Bildirim Kaydı
                    Bildirim bildirim = new Bildirim
                    {
                        goruldu_mu = false,
                        mesaj = "Hoşgeldiniz, " + sonuc.Veri.ad + " " + sonuc.Veri.soyad + "! Sisteme Kaydınız Gerçekleştirildi. Varsayılan olarak şifreniz, T.C.Kimlik numaranız olarak sisteme kaydedilmiştir. Güvenliğiniz için güncellemenizi öneririz.",
                        personel_tc = sonuc.Veri.personel_tc,
                        session_personel_tc = online_personel.personel_tc,
                        tarih = DateTime.Now,
                        tur_id = Sabitler.BildirimTur_PersonelKaydi
                    };
                    bildirim_veritabani.Ekle(bildirim);
                    #endregion
                }
                else
                {
                    divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                    if(sonuc.hata != null)
                    {
                        //HATA KAYDI YAP SİSTEM HATASI VAR
                    }
                    else
                    {
                        
                    }
                }                
            }
            catch(Exception ex)
            {
                divBilgiMesaji.Attributes.Add("class", "alert alert-danger");
                divBilgiMesaji.InnerText = "Lütfen Girdiğiniz Bilgileri Kontrol Ediniz! Formata Uygun Veriler Giriniz..";
                //Hatayı Kaydet
            }
        }
    }
}