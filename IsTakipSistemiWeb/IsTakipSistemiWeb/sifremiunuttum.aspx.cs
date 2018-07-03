using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Yardimci;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;

namespace IsTakipSistemiWeb
{
    public partial class sifremiunuttum : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();
        Mail_Sinifi mail_sinifi = new Mail_Sinifi();
        MailAyar_Veritabani mailayar_veritabani = new MailAyar_Veritabani();
        Hata_Veritabani hata_veritabani = new Hata_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                divBilgiMesaji.Visible = false;
            }
        }

        protected void BtnHatirlat_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;

            var sonuc_mailayar = mailayar_veritabani.DetayGetir();
            if(sonuc_mailayar.basariliMi)
            {
                var sonuc = personel_veritabani.DetayGetir(TxtKullaniciAd.Text);
                if (sonuc.basariliMi)
                {
                    string alici = sonuc.Veri.mail;
                    string adsoyad = sonuc.Veri.ad + " " + sonuc.Veri.soyad;
                    string sifre = sonuc.Veri.sifre;
                    string konu = "Şifre Hatırlatma";
                    string icerik = "Sayın <b>" + adsoyad + ";</b><br><br>" + "<b>Unuttuğunuz Şifreniz:</b> " + sifre + "<br><br>" + "<b><i>İş Takip Sistemi</i></b>";
                    var mail_sonuc = mail_sinifi.MailGonder(konu, alici, icerik, sonuc_mailayar.Veri);
                    if (mail_sonuc.basariliMi)
                    {
                        spBilgiMesajiIcerik.InnerText = mail_sonuc.mesaj;
                    }
                    else
                    {
                        if (mail_sonuc.hata != null)
                        {
                            //HATA KAYDI
                            NHata nesne_hata = mail_sonuc.hata;
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

                            spBilgiMesajiIcerik.InnerText = mail_sonuc.mesaj;
                        }
                        spBilgiMesajiIcerik.InnerText = mail_sonuc.mesaj;
                    }
                }
                else
                {
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
                    spBilgiMesajiIcerik.InnerText = sonuc.mesaj;
                }
            }
            else
            {
                if (sonuc_mailayar.hata != null)
                {
                    //HATA KAYDI
                    NHata nesne_hata = sonuc_mailayar.hata;
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
                spBilgiMesajiIcerik.InnerText = sonuc_mailayar.mesaj;
            }
           
        }
    }
}