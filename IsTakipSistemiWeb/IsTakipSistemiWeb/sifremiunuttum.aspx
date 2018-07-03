<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sifremiunuttum.aspx.cs" Inherits="IsTakipSistemiWeb.sifremiunuttum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
        <title>İTS | Şifremi Unuttum</title>
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
            <a href="login.aspx">İŞ TAKİP SİSTEMİ</a>               
        </div>

        <div class="content">
                <h3 class="font-green">Şifremi Unuttum?</h3>
                
                <div runat="server" id="divBilgiMesaji" class="alert alert-danger">
                            <button class="close" data-close="alert"></button>
                            <span runat="server" id="spBilgiMesajiIcerik"></span>
                </div>

                <p> Parolanızı Öğrenmek İçin T.C.Kimlik Numaranızı Giriniz. </p>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="TxtKullaniciAd" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Personel T.C. Kimlik No"></asp:TextBox> </div>
                <div class="form-actions">
                    <asp:Button runat="server" ID="BtnHatirlat" CssClass="btn green uppercase" Text="DEVAM ET" OnClick="BtnHatirlat_Click"/>
                </div>
        </div>

    </form>
</body>
</html>
