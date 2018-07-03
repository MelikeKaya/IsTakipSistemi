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
    public partial class is_turleri : System.Web.UI.Page
    {
        IsTur_Veritabani isTur_Veritabani = new IsTur_Veritabani();

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
                IsTur tur = new IsTur
                {
                    ad = TxtTurAd.Text,
                };

                var sonuc = isTur_Veritabani.Ekle(tur);

                if (sonuc.basariliMi)
                {
                    Listele();
                }
            }
        }

        private void Listele()
        {
            var sonuc = isTur_Veritabani.Listele();
            if (sonuc.basariliMi)
            {
                RptTurler.DataSource = sonuc.Veri;
                RptTurler.DataBind();
            }
        }
    }
}