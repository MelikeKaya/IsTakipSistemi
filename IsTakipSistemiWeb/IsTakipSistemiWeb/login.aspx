<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="IsTakipSistemiWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
        <title>İTS | Kullanıcı Giriş Sayfası</title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <meta content="" name="description" />
        <meta content="" name="author" />
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
        <link href="/Tema/assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
        <link href="/Tema/assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
        <link rel="shortcut icon" href="favicon.ico" />
</head>

<body class="login">
    <form id="form1" runat="server">

        <div class="logo">
            <a href="/login.aspx"><img src="/Images/its-logo.png" width="300" height="130" /></a>               
        </div>

        <asp:ScriptManager runat="server" ID="MainScriptManager" />

        <asp:UpdatePanel runat="server" ID="PnlLoginUP">
            <ContentTemplate>
                
                <div class="content">

                        <h3 class="form-title font-green">Kullanıcı Girişi</h3>

                        <div runat="server" id="divBilgiMesaji" class="alert alert-danger">
                            <button class="close" data-close="alert"></button>
                            <span runat="server" id="spBilgiMesajiIcerik"></span>
                        </div>

                        <div class="form-group">
                            <asp:TextBox runat="server" ID="TxtKullaniciAd" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Personel T.C. Kimlik No"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:TextBox runat="server" ID="TxtSifre" TextMode="Password" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Şifre"></asp:TextBox>
                        </div>
                            
                        <div class="form-actions">
                            <asp:Button runat="server" ID="BtnGirisYap" CssClass="btn green uppercase" Text="GİRİŞ YAP" OnClick="BtnGirisYap_Click"/>
                            <a href="/sifremiunuttum.aspx" id="forget-password" class="forget-password">Şifremi Unuttum?</a>
                        </div>
            
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        

        <div class="copyright"> 2018 © İş Takip Sistemi. Yönetim Paneli </div>

    </form>

        <script src="/Tema/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/global/scripts/app.min.js" type="text/javascript"></script>
        <script src="/Tema/assets/pages/scripts/login.min.js" type="text/javascript"></script>

</body>

</html>
