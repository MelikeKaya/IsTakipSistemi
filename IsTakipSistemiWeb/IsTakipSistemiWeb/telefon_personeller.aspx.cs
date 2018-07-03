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
    public partial class telefon_personeller : System.Web.UI.Page
    {
        Personel_Veritabani personel_Veritabani = new Personel_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = personel_Veritabani.TumPersonelleriListele();
                if(sonuc.basariliMi)
                {
                    RptRehber.DataSource = sonuc.Veri;
                    RptRehber.DataBind();
                }
            }
        }
    }
}