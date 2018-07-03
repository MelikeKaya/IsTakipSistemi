<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="is_kaydi.aspx.cs" Inherits="IsTakipSistemiWeb.is_kaydi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İş Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>İş Kayıt Formu</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">YENİ İŞ KAYDI</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">                                       

                                        <div class="col-md-6">       
                                            
                                            <div class="form-group">
                                                <label>Firma:</label>
                                                <asp:DropDownList runat="server" ID="DrpFirma" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Tür:</label>
                                                <asp:DropDownList runat="server" ID="DrpTur" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Durum:</label>
                                                <asp:DropDownList runat="server" ID="DrpDurum" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Kayıt Tarihi:</label>
                                                <asp:TextBox type="date" runat="server" ID="TxtKayitTarih" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Başlık:</label>
                                                <asp:TextBox runat="server" ID="TxtBaslik" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Açıklama:</label>
                                                <asp:TextBox runat="server" ID="TxtAciklama" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-6">       
                                            
                                            <div class="form-group">
                                                <label>Süre (Gün):</label>
                                                <asp:TextBox runat="server" ID="TxtGun" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Alınacak Ücret (TL):</label>
                                                <asp:TextBox runat="server" ID="TxtAlinacak" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Alınan Ücret (TL):</label>
                                                <asp:TextBox runat="server" ID="TxtAlinan" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Aylık Sabit Ücret (TL):</label>
                                                <asp:TextBox runat="server" ID="TxtAylik" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Yıllık Sabit Ücret (TL):</label>
                                                <asp:TextBox runat="server" ID="TxtYillik" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Sözleşme:</label>
                                                <asp:TextBox runat="server" ID="TxtAdres" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>


                                        <div class="col-md-12">
                                            <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div runat="server" class="alert alert-info">Bilgiler İşleniyor, Lütfen Bekleyin...</div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div runat="server" id="divBilgiMesaji" class="alert alert-danger">Hata Mesajı</div>
                                            <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-success btn-block" Text="Bilgileri Kaydet" OnClick="BtnKaydet_Click" />
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
