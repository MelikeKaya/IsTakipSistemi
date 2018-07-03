using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Nesne;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Yardimci;

namespace IsTakipSistemiWeb
{
    public partial class toplu_mail_gonder : System.Web.UI.Page
    {
        Personel_Veritabani personel_Veritabani = new Personel_Veritabani();
        Firma_Veritabani firma_Veritabani = new Firma_Veritabani();
        MailAyar_Veritabani mailAyar_veritabani = new MailAyar_Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                divBilgiMesaji.Visible = false;
                RdPersonel.Checked = true;
            }
        }

        protected void BtnGonder_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;

            List<ViewPersonel> listePersonel = personel_Veritabani.TumPersonelleriListele().Veri;
            List<ViewFirma> listeFirma = firma_Veritabani.TumFirmalariListele().Veri;

            if(RdFirmalar.Checked == true)
            {
                foreach(ViewFirma item in listeFirma)
                {
                    string konu = TxtKonu.Text;
                    string icerik = TxtIcerik.Text;
                    string alici = item.mail;

                    try
                    {
                        Mail_Sinifi mail_Sinifi = new Mail_Sinifi();
                        mail_Sinifi.MailGonder(konu, alici, icerik, mailAyar_veritabani.DetayGetir().Veri);
                    }
                    catch
                    {

                    }
                }
            }
            else if (RdPersonel.Checked == true)
            {
                foreach (ViewPersonel item in listePersonel)
                {
                    string konu = TxtKonu.Text;
                    string icerik = TxtIcerik.Text;
                    string alici = item.mail;

                    try
                    {
                        Mail_Sinifi mail_Sinifi = new Mail_Sinifi();
                        mail_Sinifi.MailGonder(konu, alici, icerik, mailAyar_veritabani.DetayGetir().Veri);
                    }
                    catch
                    {

                    }
                }
            }

            divBilgiMesaji.InnerText = "Mail Gönderimi Başarılı!";
        }
    }
}