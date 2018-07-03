using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Entity;

namespace IsTakipSistemiWeb
{
    public partial class is_gorevlendirme : System.Web.UI.Page
    {
        Is_Veritabani isVeritabani = new Is_Veritabani();
        IsPersonelOrtak_Veritabani isPersonelOrtakVeritabani = new IsPersonelOrtak_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                List<ViewIsListesi> sonucIsListesi = isVeritabani.Listele().Veri;
                DrpIsler.DataSource = sonucIsListesi;
                DrpIsler.DataTextField = "baslik";
                DrpIsler.DataValueField = "is_id";
                DrpIsler.DataBind();
            }
        }

        protected void BtnSorgula_Click(object sender, EventArgs e)
        {
            int is_id = int.Parse(DrpIsler.SelectedValue.ToString());
            List<ViewGorevlendirme> sonucGorevListesi = isPersonelOrtakVeritabani.Listele(is_id).Veri;
            RptGorevlendirme.DataSource = sonucGorevListesi;
            RptGorevlendirme.DataBind();
        }
    }
}