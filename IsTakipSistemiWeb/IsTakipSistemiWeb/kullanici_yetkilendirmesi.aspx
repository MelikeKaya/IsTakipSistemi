<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="kullanici_yetkilendirmesi.aspx.cs" Inherits="IsTakipSistemiWeb.kullanici_yetkilendirmesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Genel Ayarlar</a><i class="fa fa-circle"></i></li>                  
                <li><span>Kullanıcı Yetkilendirmesi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">KULLANICI YETKİLENDİRMESİ</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-12">

                                            
                                         
                                            <div class="col-md-12" style="padding-left:0px;">

                                                <div class="form-group">
                                                    <asp:DropDownList runat="server" ID="DrpRoller" AutoPostBack="true" CssClass="form-control input-sm" OnSelectedIndexChanged="DrpRoller_SelectedIndexChanged"></asp:DropDownList>
                                                </div>

                                            </div>
                                                

                                           

                                        </div>
                                        
                                        

                                    </div>

                                        <div class="row">

                                            
                                            <div class="col-md-12">

                                                <div class="col-md-3">
                                                            <div class="form-group">


                                                                <label class="mt-checkbox"> <b>Tümünü Seç</b>
                                                                    <asp:CheckBox runat="server" ID="ChkTumunuSec" OnCheckedChanged="ChkTumunuSec_CheckedChanged" AutoPostBack="true" />
                                                                    <span></span>
                                                                </label>

                                                                
                                                                
                                                                
                                                            </div>
                                                        </div>

                                                <div class="col-md-3">
                                                            <div class="form-group">


                                                                <label class="mt-checkbox"> <b>Temizle</b>
                                                                    <asp:CheckBox runat="server" ID="ChkTemizle" OnCheckedChanged="ChkTemizle_CheckedChanged" AutoPostBack="true" />
                                                                    <span></span>
                                                                </label>

                                                                
                                                                
                                                                
                                                            </div>
                                                        </div>

                                                <div class="col-md-6"></div><div class="clearfix"></div>
                                                
                                                <asp:Repeater runat="server" ID="RptHaklar">
                                                    <ItemTemplate>
                                                        <div class="col-md-3">
                                                            <div class="form-group">

                                                                <asp:Label runat="server" Visible="false" ID="LblHakId" Text='<%#Eval("hak_id") %>'></asp:Label>

                                                                <label class="mt-checkbox"> <%#Eval("ad") %>
                                                                    <asp:CheckBox runat="server" ID="ChkHak" OnCheckedChanged="ChkHak_CheckedChanged" AutoPostBack="true" />
                                                                    <span></span>
                                                                </label>

                                                                
                                                                
                                                                
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            
                                            </div>

                                            <div class="col-md-12">
                                                <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                                                    <ProgressTemplate>
                                                        <div runat="server" class="alert alert-info">Bilgiler İşleniyor, Lütfen Bekleyin...</div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <div runat="server" id="divBilgiMesaji" class="alert alert-danger">Hata Mesajı</div>
                                                <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-success btn-block" Text="Değişiklikleri Kaydet" OnClick="BtnKaydet_Click" />
                                            </div>

                                        </div>

                                    </div>
                                                    
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>
            </ContentTemplate></asp:UpdatePanel>
                        </div>                   
                        
    </div>

</asp:Content>
