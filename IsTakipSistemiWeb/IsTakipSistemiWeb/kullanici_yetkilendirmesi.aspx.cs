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
    public partial class kullanici_yetkilendirmesi : System.Web.UI.Page
    {
        RolHak_Veritabani rolHak_veritabani = new RolHak_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var sonuc = rolHak_veritabani.RolListele();
                DrpRoller.DataSource = sonuc.Veri;
                DrpRoller.DataTextField = "ad";
                DrpRoller.DataValueField = "rol_id";
                DrpRoller.DataBind();

                var sonucHak = rolHak_veritabani.HakListele();
                RptHaklar.DataSource = sonucHak.Veri;
                RptHaklar.DataBind();

                divBilgiMesaji.Visible = false;
            }
        }

        protected void DrpRoller_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);

            var sonuc = rolHak_veritabani.HakListele();
            RptHaklar.DataSource = sonuc.Veri;
            RptHaklar.DataBind();

            int secilenRolId = int.Parse(DrpRoller.SelectedValue);
            List<ViewRolHak> rolHakListesi = rolHak_veritabani.Listele().Veri;
            List<int> hakListesi = (from rh in rolHakListesi where rh.rol_id == secilenRolId select rh.hak_id).ToList();

            foreach (RepeaterItem item in this.RptHaklar.Items)
            {
                Label label = item.FindControl("LblHakId") as Label;
                CheckBox check = item.FindControl("ChkHak") as CheckBox;
                int hakId = int.Parse(label.Text);
                if (hakListesi.Contains(hakId))
                {
                    check.Checked = true;
                }
                else
                {
                    check.Checked = false;
                }
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            int secilenRolId = int.Parse(DrpRoller.SelectedValue);

            var silmeSonuc = rolHak_veritabani.Role_Ait_Kayitlari_Sil(secilenRolId);
            if(silmeSonuc.basariliMi)
            {
                foreach (RepeaterItem item in this.RptHaklar.Items)
                {
                    Label label = item.FindControl("LblHakId") as Label;
                    CheckBox check = item.FindControl("ChkHak") as CheckBox;
                    int hakId = int.Parse(label.Text);
                    if (check.Checked)
                    {
                        RolHak data = new RolHak
                        {
                            hak_id = hakId,
                            rol_id = secilenRolId
                        };
                        rolHak_veritabani.RolHak_Ekle(data);
                    }
                }
            }

            divBilgiMesaji.Attributes.Add("class", "alert alert-success");
            divBilgiMesaji.InnerText = "Değişiklikler Başarıyla Kaydedildi!";
        }

        protected void ChkTumunuSec_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuSec.Checked)
            {
                foreach (RepeaterItem item in this.RptHaklar.Items)
                {
                    CheckBox check = item.FindControl("ChkHak") as CheckBox;
                    check.Checked = true;
                }
                ChkTemizle.Checked = false;
            }
            else
            {

            }           
        }

        protected void ChkTemizle_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkTemizle.Checked)
            {
                foreach (RepeaterItem item in this.RptHaklar.Items)
                {
                    CheckBox check = item.FindControl("ChkHak") as CheckBox;
                    check.Checked = false;
                }
                ChkTumunuSec.Checked = false;
            }
            else
            {
                
            }           
        }

        protected void ChkHak_CheckedChanged(object sender, EventArgs e)
        {
            ChkTumunuSec.Checked = true;
            ChkTemizle.Checked = false;

            foreach (RepeaterItem item in this.RptHaklar.Items)
            {
                CheckBox check = item.FindControl("ChkHak") as CheckBox;
                if(check.Checked)
                {

                }
                else
                {
                    ChkTumunuSec.Checked = false;
                    ChkTemizle.Checked = true;
                    break;
                }
            }
        }
    }
}