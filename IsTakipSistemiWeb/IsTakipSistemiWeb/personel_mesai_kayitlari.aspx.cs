using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Yardimci;

namespace IsTakipSistemiWeb
{
    public partial class personel_mesai_kayitlari : System.Web.UI.Page
    {
        Personel_Veritabani personelVeritabani = new Personel_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = personelVeritabani.MesaiKayitlariniListele();
                RptMesaiKayitlari.DataSource = sonuc.Veri;
                RptMesaiKayitlari.DataBind();
            }
        }
    }
}