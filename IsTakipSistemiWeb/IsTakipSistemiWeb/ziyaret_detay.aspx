<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="ziyaret_detay.aspx.cs" Inherits="IsTakipSistemiWeb.ziyaret_detay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function myFunction() {
            window.print();
        }
    </script>
    <style>
        @media print {
          #btnYazdir {
            display: none;
          }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Ziyaret Listesi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Ziyaret Detayı</span></li>                     
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
                                            <span class="caption-subject font-red sbold uppercase">ZİYARET DETAYI</span>
                                        </div>
                                        <div class="actions">
                                            <button onclick="myFunction()" class="btn btn-success" id="btnYazdir">Yazdır</button>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">                                       

                                            <div class="col-md-6" id="parea">       
                                            
                                                <div class="portlet light portlet-fit bordered">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="icon-settings font-red"></i>
                                                            <span class="caption-subject font-red sbold">Firma Bilgileri</span>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row" style="padding-left:20px!important; padding-right:20px!important">
                                                            <div class="form-group">
                                                                <label>SGK Numarası:</label>
                                                                <asp:TextBox runat="server" ID="TxtFirmaSgk" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Unvan:</label>
                                                                <asp:TextBox runat="server" ID="TxtFirmaUnvan" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Durum:</label>
                                                                <asp:DropDownList runat="server" ID="DrpFirmaDurum" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Telefon:</label>
                                                                <asp:TextBox runat="server" ID="TxtFirmaTelefon" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Adres:</label>
                                                                <asp:TextBox runat="server" ID="TxtFirmaAdres" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-6">       
                                            
                                                <div class="portlet light portlet-fit bordered">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="icon-settings font-red"></i>
                                                            <span class="caption-subject font-red sbold">Kullanıcı Bilgileri</span>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row" style="padding-left:20px!important; padding-right:20px!important">
                                                            <div class="form-group">
                                                                <label>T.C. Kimlik Numarası:</label>
                                                                <asp:TextBox runat="server" ID="TxtPersonelTC" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Adı & Soyadı:</label>
                                                                <asp:TextBox runat="server" ID="TxtPersonelAdSoyad" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Görevi:</label>
                                                                <asp:DropDownList runat="server" ID="DrpPersonelGorev" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Telefon:</label>
                                                                <asp:TextBox runat="server" ID="TxtPersonelTelefon" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Mail Adresi:</label>
                                                                <asp:TextBox runat="server" ID="TxtPersonelMail" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12">

                                                <div class="portlet light portlet-fit bordered">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="icon-settings font-red"></i>
                                                            <span class="caption-subject font-red sbold">Ziyaret Bilgileri</span>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row" style="padding-left:20px!important; padding-right:20px!important">
                                                            <div class="form-group">
                                                                <label>Ziyaret Türü:</label>
                                                                <asp:DropDownList runat="server" ID="DrpZiyaretTur" CssClass="form-control input-sm" Enabled="false"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Giriş Tarihi:</label>
                                                                <asp:TextBox runat="server" ID="TxtGirisTarihi" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Çıkış Tarihi:</label>
                                                                <asp:TextBox runat="server" ID="TxtCikisTarihi" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>Açıklama:</label>
                                                                <asp:TextBox runat="server" ID="TxtZiyaretAciklama" TextMode="MultiLine" Rows="10" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>


                                       
                                        
                                        

                                        </div>

                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>

                        </div>                   
                        
    </div>

</asp:Content>
