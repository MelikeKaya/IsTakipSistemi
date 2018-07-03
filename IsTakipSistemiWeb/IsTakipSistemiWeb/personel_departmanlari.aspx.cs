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
    public partial class personel_departmanlari : System.Web.UI.Page
    {
        PersonelDepartman_Veritabani departman_veritabani = new PersonelDepartman_Veritabani();
        Personel_Veritabani personel_veritabani = new Personel_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = personel_veritabani.TumPersonelleriListele();
                if(sonuc.basariliMi)
                {
                    DrpPersonel.DataSource = sonuc.Veri.ToList();
                    DrpPersonel.DataTextField = "adsoyad";
                    DrpPersonel.DataValueField = "tc";
                    DrpPersonel.DataBind();
                    DrpPersonel.Items.Insert(0, new ListItem("Sorumlu Personel Seçiniz (Varsayılan << Ben >>)", "0"));
                }
                Listele();
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(TxtDepartmanAd.Text != "")
            {
                string sorumlu_tc = "";

                if(DrpPersonel.SelectedValue.ToString() == "0")
                {
                    Personel online_personel = Session["kullanici"] as Personel;
                    sorumlu_tc = online_personel.personel_tc;
                }
                else
                {
                    sorumlu_tc = DrpPersonel.SelectedValue.ToString();
                }

                PersonelDepartman departman = new PersonelDepartman
                {
                    ad = TxtDepartmanAd.Text,
                    sorumlu_personel_tc = sorumlu_tc
                };

                var sonuc = departman_veritabani.Ekle(departman);

                if (sonuc.basariliMi)
                {
                    Listele();
                }
            }            
        }
        private void Listele()
        {
            var sonuc = departman_veritabani.Listele();
            if(sonuc.basariliMi)
            {
                RptDepartmanlar.DataSource = sonuc.Veri;
                RptDepartmanlar.DataBind();
            }
        }
    }
}