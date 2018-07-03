<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IsTakipSistemiWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>                 
            </ul>                   
        </div>        
        <br />        
        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 blue" href="#">
                                    <div class="visual">
                                        <i class="fa fa-comments"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spAktifFirma" data-counter="counterup" data-value="1349">0</span>
                                        </div>
                                        <div class="desc"> Aktif Firma </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 red" href="#">
                                    <div class="visual">
                                        <i class="fa fa-bar-chart-o"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spPasifFirma" data-counter="counterup" data-value="12,5">0</span></div>
                                        <div class="desc"> Pasif Firma </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 green" href="#">
                                    <div class="visual">
                                        <i class="fa fa-shopping-cart"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spTeklifFirma" data-counter="counterup" data-value="549">0</span>
                                        </div>
                                        <div class="desc"> Teklif Aşamasında Firma </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 purple" href="#">
                                    <div class="visual">
                                        <i class="fa fa-globe"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spToplamFirma" data-counter="counterup" data-value="89"></span></div>
                                        <div class="desc"> Toplam Kayıtlı Firma </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="clearfix"></div>    
        
        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 blue" href="#">
                                    <div class="visual">
                                        <i class="fa fa-comments"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spPersonel" data-counter="counterup" data-value="1349">0</span>
                                        </div>
                                        <div class="desc"> Kayıtlı Personel </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 red" href="#">
                                    <div class="visual">
                                        <i class="fa fa-bar-chart-o"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spBitenIs" data-counter="counterup" data-value="12,5">0</span></div>
                                        <div class="desc"> Biten İş </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 green" href="#">
                                    <div class="visual">
                                        <i class="fa fa-shopping-cart"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spPasifIs" data-counter="counterup" data-value="549">0</span>
                                        </div>
                                        <div class="desc"> Pasif İş </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <a class="dashboard-stat dashboard-stat-v2 purple" href="#">
                                    <div class="visual">
                                        <i class="fa fa-globe"></i>
                                    </div>
                                    <div class="details">
                                        <div class="number">
                                            <span runat="server" id="spToplamIs" data-counter="counterup" data-value="89"></span></div>
                                        <div class="desc"> Toplam İş Sayısı </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="clearfix"></div>


       
                        
    </div>

</asp:Content>
