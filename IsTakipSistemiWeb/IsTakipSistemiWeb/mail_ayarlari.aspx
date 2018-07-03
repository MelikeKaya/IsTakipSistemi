<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="mail_ayarlari.aspx.cs" Inherits="IsTakipSistemiWeb.mail_ayarlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Genel Ayarlar</a><i class="fa fa-circle"></i></li>                  
                <li><span>Mail Ayarları</span></li>                    
            </ul>                   
        </div>        
        <br />        
        <div class="row">
            <asp:ScriptManager runat="server" ID="ScriptMgr"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdatePnl">
                <ContentTemplate>
                            <div class="col-md-12">
                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                <div class="portlet light portlet-fit bordered">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="icon-settings font-red"></i>
                                            <span class="caption-subject font-red sbold uppercase">MAİL AYARLARI</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-9">

                                            <div class="form-group">
                                                <label>Mail Adresi:</label>
                                                <asp:TextBox runat="server" ID="TxtMail" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Mail Şifresi:</label>
                                                <asp:TextBox runat="server" TextMode="Password" ID="TxtSifre" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Mail Şifresi(Tekrar):</label>
                                                <asp:TextBox runat="server" TextMode="Password" ID="TxtSifreTekrar" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Host:</label>
                                                <asp:TextBox runat="server" ID="TxtHost" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Port:</label>
                                                <asp:TextBox runat="server" ID="TxtPort" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>SSL Aktiflik Durumu:</label>
                                                <div class="mt-radio-inline">
                                                        <label class="mt-radio">
                                                            <asp:RadioButton runat="server" ID="RdAcikSsl" Text="Açık" GroupName="Ssl" Checked="true" />
                                                            <span></span>
                                                        </label>
                                                        <label class="mt-radio">
                                                            <asp:RadioButton runat="server" ID="RdKapaliSsl" Text="Kapalı" GroupName="Ssl" />
                                                            <span></span>
                                                        </label>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-3">

                                          

                                        </div>
                                        
                                        <div class="col-md-12">
                                            <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div runat="server" class="alert alert-info">Bilgiler İşleniyor, Lütfen Bekleyin...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div runat="server" id="divBilgiMesaji" class="alert alert-danger">Hata Mesajı</div>
                                            <asp:Button runat="server" ID="BtnGuncelle" CssClass="btn btn-primary btn-block" Text="Ayarları Güncelle" OnClick="BtnGuncelle_Click" />
                                        </div>
                                        
                                        

                                    </div></div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </div>                   
                        
    </div>


</asp:Content>
