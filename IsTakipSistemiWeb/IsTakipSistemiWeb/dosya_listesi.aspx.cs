using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;

namespace IsTakipSistemiWeb
{
    public partial class dosya_listesi : System.Web.UI.Page
    {
        Dosya_Veritabani dosya_Veritabani = new Dosya_Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = dosya_Veritabani.Listele();
                if(sonuc.basariliMi)
                {
                    RptDosyalar.DataSource = sonuc.Veri;
                    RptDosyalar.DataBind();
                }
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DownloadFile.ashx?filePath=FrameworkContracts.dll");
        }
    }
}