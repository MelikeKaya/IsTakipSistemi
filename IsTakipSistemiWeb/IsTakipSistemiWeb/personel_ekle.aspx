<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="personel_ekle.aspx.cs" Inherits="IsTakipSistemiWeb.personel_ekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Personel Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Personel Kayıt Formu</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">YENİ PERSONEL KAYDI</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-9">

                                            
                                         

                                                

                                            

                                            <div class="form-group">
                                                <label>T.C.Kimlik No:</label>
                                                <asp:TextBox runat="server" ID="TxtTc" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Sicil No:</label>
                                                <asp:TextBox runat="server" ID="TxtSicil" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Ad:</label>
                                                <asp:TextBox runat="server" ID="TxtAd" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Soyad:</label>
                                                <asp:TextBox runat="server" ID="TxtSoyad" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-3">

                                            <img style="width:100%; height:100%;" src="/Images/Personel/default.png" />

                                        </div>

                                        <div class="col-md-6">                                          

                                            <div class="form-group">
                                                <label>Departman:</label>
                                                <asp:DropDownList runat="server" ID="DrpDepartman" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Tip:</label>
                                                <asp:DropDownList runat="server" ID="DrpTip" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label>Unvan:</label>
                                                <asp:TextBox runat="server" ID="TxtUnvan" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Varsayılan Giriş Saati:</label>
                                                <input type="time" runat="server" id="TimeGiris" class="form-control" />
                                            </div>

                                            <div class="form-group">
                                                <label>Varsayılan Çıkış Saati:</label>
                                                <input type="time" runat="server" id="TimeCikis" class="form-control" />
                                            </div>

                                            <div class="form-group">
                                                <label>Aylık Net Maaş (TL)</label>
                                                <asp:TextBox runat="server" ID="TxtMaas" CssClass="form-control"></asp:TextBox>
                                            </div> 

                                            <div class="form-group">
                                                <label>Cinsiyet:</label>
                                                <div class="mt-radio-inline">
                                                        <label class="mt-radio">
                                                            <asp:RadioButton runat="server" ID="RdErkek" Text="Erkek" GroupName="Cinsiyet" Checked="true" />
                                                            <span></span>
                                                        </label>
                                                        <label class="mt-radio">
                                                            <asp:RadioButton runat="server" ID="RdKadin" Text="Kadın" GroupName="Cinsiyet" />
                                                            <span></span>
                                                        </label>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6">

                                            <div class="form-group">
                                                <label>Mail Adresi:</label>
                                                <asp:TextBox runat="server" ID="TxtMail" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Telefon:</label>
                                                <asp:TextBox runat="server" ID="TxtTelefon" CssClass="form-control"></asp:TextBox>
                                            </div>                                            

                                            <div class="form-group">
                                                <label>Doğum Tarihi:</label>
                                                <input type="date" runat="server" id="DateDogum" class="form-control" />
                                            </div>

                                            <div class="form-group">
                                                <label>İşe Giriş Tarihi:</label>
                                                <input type="date" runat="server" id="DateIseGiris" class="form-control" />
                                            </div>

                                            <div class="form-group">
                                                <label>Ek Mesai Ücreti (Saatlik):</label>
                                                <asp:TextBox runat="server" ID="TxtEkMesaiUcret" CssClass="form-control"></asp:TextBox>
                                            </div> 

                                            <div class="form-group">
                                                <label>Adres:</label>
                                                <asp:TextBox runat="server" ID="TxtAdres" TextMode="MultiLine" CssClass="form-control" Style="height:110px"></asp:TextBox>
                                            </div>

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
