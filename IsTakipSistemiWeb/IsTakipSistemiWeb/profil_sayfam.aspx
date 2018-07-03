<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="profil_sayfam.aspx.cs" Inherits="IsTakipSistemiWeb.profil_sayfam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Ayarlar</a><i class="fa fa-circle"></i></li>                  
                <li><span>Profil Sayfam</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase" runat="server" id="spanAdSoyad"></span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-9">

                                            
                                         

                                                

                                            

                                            <div class="form-group">
                                                <label>T.C.Kimlik No:</label>
                                                <asp:TextBox runat="server" ID="TxtTc" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Mail Adresi:</label>
                                                <asp:TextBox runat="server" ID="TxtMail" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Telefon:</label>
                                                <asp:TextBox runat="server" ID="TxtTelefon" CssClass="form-control"></asp:TextBox>
                                            </div> 

                                            <div class="form-group">
                                                <label>Adres:</label>
                                                <asp:TextBox runat="server" ID="TxtAdres" TextMode="MultiLine" CssClass="form-control" Style="height:110px"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Yeni Şifre:</label>
                                                <asp:TextBox runat="server" ID="TxtSifre" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Yeni Şifre (Tekrar):</label>
                                                <asp:TextBox runat="server" ID="TxtSifreTekrar" CssClass="form-control"></asp:TextBox>
                                            </div>


                                        </div>

                                        <div class="col-md-3"></div>


                                        <div class="col-md-12">
                                            <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div runat="server" class="alert alert-info">Bilgiler İşleniyor, Lütfen Bekleyin...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div runat="server" id="divBilgiMesaji" class="alert alert-danger">Hata Mesajı</div>
                                            <asp:Button runat="server" ID="BtnGuncelle" CssClass="btn btn-success btn-block" Text="Bilgileri Güncelle" OnClick="BtnGuncelle_Click" />
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
