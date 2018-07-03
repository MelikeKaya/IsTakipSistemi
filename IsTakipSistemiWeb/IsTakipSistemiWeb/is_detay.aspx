<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="is_detay.aspx.cs" Inherits="IsTakipSistemiWeb.is_detay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İş Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>İş Detayı</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase"><asp:Label runat="server" ID="LblIsBaslik"></asp:Label></span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">                                       

                                        <div class="col-md-6">       
                                            
                                            <div class="form-group">
                                                <label>Hizmet Verilen Firma:</label>
                                                <asp:Label runat="server" ID="LblFirmaAdi"></asp:Label>
                                            </div>

                                            <div class="form-group">
                                                <label>İş Türü:</label>
                                                <asp:Label runat="server" ID="LblTurAdi"></asp:Label>
                                            </div>

                                            <div class="form-group">
                                                <label>Sorumlu Personel:</label>
                                                <asp:Label runat="server" ID="LblSorumluPersonel"></asp:Label>
                                            </div>

                                            <div class="form-group">
                                                <label>Açıklama:</label>
                                                <asp:Label runat="server" ID="LblAciklama"></asp:Label>
                                            </div>

                                           
                                        </div>

                                        <div class="col-md-6">       
                                            
                                                <asp:Repeater runat="server" ID="RptPersoneller">
                                                    <ItemTemplate>
                                                        <div class="col-md-3">
                                                            <div class="form-group">

                                                                <asp:Label runat="server" Visible="false" ID="LblPersonelTc" Text='<%#Eval("tc") %>'></asp:Label>

                                                                <label class="mt-checkbox"> <%#Eval("adsoyad") %>
                                                                    <asp:CheckBox runat="server" ID="ChkPersonel" OnCheckedChanged="ChkPersonel_CheckedChanged" AutoPostBack="true" />
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
                                            <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-success btn-block" Text="Atamaları Kaydet" OnClick="BtnKaydet_Click" />
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
