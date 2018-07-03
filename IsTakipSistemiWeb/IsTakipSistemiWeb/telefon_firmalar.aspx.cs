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
    public partial class telefon_firmalar : System.Web.UI.Page
    {
        Firma_Veritabani firma_Veritabani = new Firma_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sonuc = firma_Veritabani.TumFirmalariListele();
                if (sonuc.basariliMi)
                {
                    RptRehber.DataSource = sonuc.Veri;
                    RptRehber.DataBind();
                }
            }
        }
    }
}