<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="personel_mesai_kayitlari.aspx.cs" Inherits="IsTakipSistemiWeb.personel_mesai_kayitlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Personel Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Mesai Kayıtları</span></li>                    
            </ul>                   
        </div>        
        <br />        
        <div class="row">
                            <div class="col-md-12">
                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                <div class="portlet light portlet-fit bordered">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="icon-settings font-red"></i>
                                            <span class="caption-subject font-red sbold uppercase">MESAİ KAYITLARI</span>
                                        </div>
                                        <div class="actions">
                                            <%--<a href="/personel_ekle.aspx" class="btn btn-success">Yeni Personel Kaydı</a>--%>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        
                                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                            <thead>
                                                <tr>
                                                    <th> # </th>
                                                    <th> T.C. Kimlik </th>
                                                    <th> Ad </th>
                                                    <th> Soyad </th>
                                                    <th> Tarih </th>
                                                    <th> Giriş Saati </th>
                                                    <th> Giriş Zamanı </th>
                                                    <th> Giriş Konumu </th>
                                                    <th> Çıkış Saati </th>
                                                    <th> Çıkış Zamanı </th>
                                                    <th> Çıkış Konumu </th>
                                                    <th> Toplam </th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                


                                                <asp:Repeater runat="server" ID="RptMesaiKayitlari">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="font-weight:bold"> <%#Eval("kayit_id") %> </td>
                                                            <td style="font-weight:bold"> <%#Eval("personel_tc") %> </td>
                                                            <td> <%#Eval("ad") %> </td>
                                                            <td> <%#Eval("soyad") %> </td>
                                                            <td> <%#Convert.ToDateTime(Eval("tarih")).ToShortDateString() %> </td>
                                                            <td> <%#string.Format("{0:hh\\:mm}", Eval("giris_saat")) %> </td>
                                                            
                                                            <td runat="server" style="color:#52aa5d; font-weight:bold" visible='<%#int.Parse(Eval("giris_zaman_farki").ToString()) < 0 %>'> <%#Math.Abs(int.Parse(Eval("giris_zaman_farki").ToString())) %> Dakika Erken Giriş</td>
                                                            <td runat="server" visible='<%#int.Parse(Eval("giris_zaman_farki").ToString()) == 0 %>'> Tam Zamanında </td>
                                                            <td runat="server" style="color:#ff0000; font-weight:bold" visible='<%#int.Parse(Eval("giris_zaman_farki").ToString()) > 0 %>'> <%#Math.Abs(int.Parse(Eval("giris_zaman_farki").ToString())) %> Dakika Geç Giriş</td>

                                                            <td> <b><%#Eval("giris_fark") %></b> Metre Uzaklıkta </td>

                                                            <td> <%#string.Format("{0:hh\\:mm}", Eval("cikis_saat")) %> </td>

                                                            <td runat="server" style="color:#52aa5d; font-weight:bold" visible='<%#int.Parse(Eval("cikis_zaman_farki").ToString()) < 0 %>'> <%#Math.Abs(int.Parse(Eval("cikis_zaman_farki").ToString())) %> Dakika Erken Çıkış</td>
                                                            <td runat="server" visible='<%#int.Parse(Eval("cikis_zaman_farki").ToString()) == 0 %>'> Tam Zamanında </td>
                                                            <td runat="server" style="color:#ff0000; font-weight:bold" visible='<%#int.Parse(Eval("cikis_zaman_farki").ToString()) > 0 %>'> <%#Math.Abs(int.Parse(Eval("cikis_zaman_farki").ToString())) %> Dakika Geç Çıkış</td>
                                                            
                                                            <td> <b><%#Eval("cikis_fark") %></b> Metre Uzaklıkta </td>

                                                            <td> <%#IsTakipSistemiWeb.Yardimci.String_Islemleri.DakikayiSaatOlarakYazdir(int.Parse(Eval("toplam_zaman").ToString())) %> </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                                
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>
                        </div>                   
                        
    </div>

</asp:Content>
