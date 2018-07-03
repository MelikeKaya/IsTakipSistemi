<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="ziyaret_kaydi.aspx.cs" Inherits="IsTakipSistemiWeb.ziyaret_kaydi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Ziyaret Listesi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Ziyaret Kayıt Formu</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">YENİ ZİYARET KAYDI</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">                                       

                                        <div class="col-md-6">       
                                            
                                            <div class="form-group">
                                                <label>Ziyaret Nedeni:</label>
                                                <asp:DropDownList runat="server" ID="DrpTur" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Ziyaret Edilen Firma:</label>
                                                <asp:DropDownList runat="server" ID="DrpFirma" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Açıklama:</label>
                                                <asp:TextBox runat="server" ID="TxtAciklama" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-6">       
                                            
                                            

                                        </div>


                                        <div class="col-md-12">
                                            <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div runat="server" class="alert alert-info">Bilgiler İşleniyor, Lütfen Bekleyin...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div runat="server" id="divBilgiMesaji" class="alert alert-danger">Hata Mesajı</div>
                                            <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-primary btn-block" Text="Bilgileri Kaydet" OnClick="BtnKaydet_Click" />
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
