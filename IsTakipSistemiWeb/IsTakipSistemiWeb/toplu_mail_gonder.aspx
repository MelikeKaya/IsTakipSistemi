<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="toplu_mail_gonder.aspx.cs" Inherits="IsTakipSistemiWeb.toplu_mail_gonder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İletişim Modülü</a><i class="fa fa-circle"></i></li>                  
                <li><span>Toplu Mail Gönderimi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">TOPLU MAİL GÖNDER</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">                                       

                                        <div class="col-md-9">       
                                            
                                            <div class="form-group">
                                                <label>Toplu Alıcılar:</label>
                                                <asp:RadioButton runat="server" ID="RdPersonel" Text=" Personeller" AutoPostBack="true" GroupName="alici" />
                                                <asp:RadioButton runat="server" ID="RdFirmalar" Text=" Firmalar" AutoPostBack="true" GroupName="alici" />
                                            </div>

                                            <div class="form-group">
                                                <label>Mail Konusu:</label>
                                                <asp:TextBox runat="server" ID="TxtKonu" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Mail İçeriği:</label>
                                                <asp:TextBox runat="server" ID="TxtIcerik" TextMode="MultiLine" CssClass="form-control" style="height:100px"></asp:TextBox>
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
                                            <asp:Button runat="server" ID="BtnGonder" CssClass="btn btn-primary btn-block" Text="Gönder" OnClick="BtnGonder_Click" />
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
