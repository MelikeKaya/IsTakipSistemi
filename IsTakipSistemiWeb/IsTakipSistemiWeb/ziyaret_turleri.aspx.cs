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
    public partial class ziyaret_turleri : System.Web.UI.Page
    {
        ZiyaretTur_Veritabani ziyaretTur_veritabani = new ZiyaretTur_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listele();
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtTurAd.Text != "")
            {                
                ZiyaretTur tur = new ZiyaretTur
                {
                    ad = TxtTurAd.Text,
                };

                var sonuc = ziyaretTur_veritabani.Ekle(tur);

                if (sonuc.basariliMi)
                {
                    Listele();
                }
            }
        }

        private void Listele()
        {
            var sonuc = ziyaretTur_veritabani.Listele();
            if (sonuc.basariliMi)
            {
                RptTurler.DataSource = sonuc.Veri;
                RptTurler.DataBind();
            }
        }
    }
}