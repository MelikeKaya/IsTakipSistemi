using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IsTakipSistemiWeb.Veritabani;
using IsTakipSistemiWeb.Entity;
using IsTakipSistemiWeb.Yardimci;
using System.IO;

namespace IsTakipSistemiWeb
{
    public partial class dosya_ekle : System.Web.UI.Page
    {
        Firma_Veritabani firma_Veritabani = new Firma_Veritabani();
        DosyaKategori_Veritabani dosyakategori_veritabani = new DosyaKategori_Veritabani();
        Dosya_Veritabani dosya_veritabani = new Dosya_Veritabani();
        String_Islemleri string_islemleri = new String_Islemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                divBilgiMesaji.Visible = false;

                var kategori_sonuc = dosyakategori_veritabani.Listele();
                var firma_sonuc = firma_Veritabani.TumFirmalariListele();

                if(kategori_sonuc.basariliMi && firma_sonuc.basariliMi)
                {
                    DrpKategori.DataSource = kategori_sonuc.Veri;
                    DrpFirma.DataSource = firma_sonuc.Veri;

                    DrpKategori.DataTextField = "ad";
                    DrpKategori.DataValueField = "kategori_id";

                    DrpFirma.DataTextField = "unvan";
                    DrpFirma.DataValueField = "firma_id";

                    DrpKategori.DataBind();
                    DrpFirma.DataBind();
                }
            }
        }

        protected void BtnKaydet_Click(object sender, EventArgs e)
        {
            divBilgiMesaji.Visible = true;

            try
            {
                System.Threading.Thread.Sleep(3000);

                if (FuDosya.HasFile)
                {
                    FileInfo fileInfo = new FileInfo(FuDosya.FileName);
                    Dosya dosya = new Dosya
                    {
                        baslik = TxtBaslik.Text,
                        iliskili_firma_id = int.Parse(DrpFirma.SelectedValue.ToString()),
                        kategori_id = int.Parse(DrpKategori.SelectedValue),
                        silindi_mi = false,
                        tarih = DateTime.Now,
                        uzanti = fileInfo.Extension,
                        yol = string_islemleri.BenzersizAdUret() + fileInfo.Extension,
                        yukleyen_personel_tc = (Session["kullanici"] as Personel).personel_tc,
                    };

                    var sonuc = dosya_veritabani.Ekle(dosya);
                    if(sonuc.basariliMi)
                    {
                        divBilgiMesaji.InnerText = sonuc.mesaj;

                        string kaydedilecek_yol = "/Uploads/" + dosya.yol;
                        FuDosya.SaveAs(Server.MapPath(kaydedilecek_yol));
                    }
                    else
                    {
                        divBilgiMesaji.InnerText = sonuc.mesaj;
                    }
                }
                else
                {
                    divBilgiMesaji.InnerText = "Dosya Seçiniz..!";
                }
            }
            catch(Exception ex)
            {
                divBilgiMesaji.InnerText = ex.Message;
            }
        }
    }
}