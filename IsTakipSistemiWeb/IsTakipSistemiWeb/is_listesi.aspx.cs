using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class is_listesi : System.Web.UI.Page
    {
        Is_Veritabani isVeritabani = new Is_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TumIsleriListele();
            }
        }

        private void TumIsleriListele()
        {
            var sonuc = isVeritabani.Listele();
            if (sonuc.basariliMi)
            {
                RptIsler.DataSource = sonuc.Veri;
                RptIsler.DataBind();
            }
        }

        protected void RptIsler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int isId = int.Parse(e.CommandArgument.ToString());
            if(e.CommandName == "Detay")
            {
                Response.Redirect("/is_detay.aspx?isId=" + isId + "");
            }
            else if(e.CommandName == "Atama")
            {
                Response.Redirect("/is_gorevlendirme.aspx?isId=" + isId + "");
            }
            else if (e.CommandName == "AltIs")
            {
                Response.Redirect("/is_alt_isler.aspx?isId=" + isId + "");
            }
        }
    }
}