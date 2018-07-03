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
    public partial class login : System.Web.UI.Page
    {
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                divBilgiMesaji.Visible = false;
                TxtKullaniciAd.Text = "11111111111";
                TxtSifre.Text = "1";
            }
        }

        protected void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var sonuc = personel_veritabani.GirisYap(TxtKullaniciAd.Text, TxtSifre.Text);
            divBilgiMesaji.Visible = true;
            if(sonuc.basariliMi)
            {
                Session["kullanici"] = sonuc.Veri;
                Response.Redirect("/index.aspx");
            }
            else
            {
                if(sonuc.hata != null)
                {
                    //Sistem Hatasını Veritabanına Kaydet
                }
                else
                {
                    spBilgiMesajiIcerik.InnerText = sonuc.mesaj;
                }
            }
        }
    }
}