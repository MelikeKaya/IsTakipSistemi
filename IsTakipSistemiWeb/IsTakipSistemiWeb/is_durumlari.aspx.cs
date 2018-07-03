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
    public partial class is_durumlari : System.Web.UI.Page
    {
        IsDurum_Veritabani isDurum_veritabani = new IsDurum_Veritabani();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listele();
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtDurumAd.Text != "")
            {
                IsDurum durum = new IsDurum
                {
                    ad = TxtDurumAd.Text,
                };

                var sonuc = isDurum_veritabani.Ekle(durum);

                if (sonuc.basariliMi)
                {
                    Listele();
                }
            }
        }

        private void Listele()
        {
            var sonuc = isDurum_veritabani.Listele();
            if (sonuc.basariliMi)
            {
                RptDurumlar.DataSource = sonuc.Veri;
                RptDurumlar.DataBind();
            }
        }
    }
}