using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class ziyaret_listesi : System.Web.UI.Page
    {
        Ziyaret_Veritabani ziyaretVeritabani = new Ziyaret_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = ziyaretVeritabani.Listele();
                if(sonuc.basariliMi)
                {
                    RptZiyaretler.DataSource = sonuc.Veri;
                    RptZiyaretler.DataBind();
                }
            }
        }

        protected void RptZiyaretler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if(e.CommandName == "Detay")
            {
                Response.Redirect("/ziyaret_detay.aspx?id="+id+"");
            }
        }
    }
}