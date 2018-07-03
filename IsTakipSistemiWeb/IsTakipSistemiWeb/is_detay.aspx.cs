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
    public partial class is_detay : System.Web.UI.Page
    {
        Is_Veritabani is_veritabani = new Is_Veritabani();
        IsPersonelOrtak_Veritabani isPersonelOrtak_veritabani = new IsPersonelOrtak_Veritabani();
        Personel_Veritabani personel_Veritabani = new Personel_Veritabani();
        Firma_Veritabani firma_Veritabani = new Firma_Veritabani();
        IsTur_Veritabani isTur_veritabani = new IsTur_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int isId = int.Parse(Request.QueryString["isId"]);
                var sonuc = is_veritabani.DetayGetir(isId);
                LblIsBaslik.Text = sonuc.Veri.baslik.ToString().ToUpper();

                var sonucPersonel = personel_Veritabani.TumPersonelleriListele();
                RptPersoneller.DataSource = sonucPersonel.Veri;
                RptPersoneller.DataBind();

                divBilgiMesaji.Visible = false;

                LblFirmaAdi.Text = firma_Veritabani.DetayGetir(sonuc.Veri.firma_id.Value).Veri.unvan;
                LblTurAdi.Text = isTur_veritabani.DetayGetir(sonuc.Veri.tur_id.Value).Veri.ad;
                LblSorumluPersonel.Text = sonuc.Veri.sorumlu_personel;
                LblAciklama.Text = sonuc.Veri.aciklama;
            }
        }

        protected void ChkPersonel_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            foreach (RepeaterItem item in this.RptPersoneller.Items)
            {
                Label label = item.FindControl("LblPersonelTc") as Label;
                CheckBox check = item.FindControl("ChkPersonel") as CheckBox;
                string personelTc = label.Text;
                if (check.Checked)
                {
                    IsPersonelOrtak data = new IsPersonelOrtak
                    {
                        personel_tc = personelTc,
                        is_id = int.Parse(Request.QueryString["isId"]),
                        aciklama = "",
                        gorev_baslama_tarih = DateTime.Now
                    };
                    isPersonelOrtak_veritabani.Ekle(data);
                }
            }

            divBilgiMesaji.Attributes.Add("class", "alert alert-success");
            divBilgiMesaji.InnerText = "Değişiklikler Başarıyla Kaydedildi!";

            Response.Redirect("/is_listesi.aspx");
        }
    }
}