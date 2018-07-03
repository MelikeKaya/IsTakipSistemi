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
    public partial class personel_tipleri : System.Web.UI.Page
    {
        PersonelTip_Veritabani tip_veritabani = new PersonelTip_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listele();
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtTipAd.Text != "")
            {
                PersonelTip tip = new PersonelTip
                {
                    ad = TxtTipAd.Text
                };

                var sonuc = tip_veritabani.Ekle(tip);

                if (sonuc.basariliMi)
                {
                    Listele();
                }
            }
        }

        private void Listele()
        {
            var sonuc = tip_veritabani.Listele();
            if (sonuc.basariliMi)
            {
                RptTipler.DataSource = sonuc.Veri;
                RptTipler.DataBind();
            }
        }
    }
}