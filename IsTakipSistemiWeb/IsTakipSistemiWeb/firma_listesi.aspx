<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="firma_listesi.aspx.cs" Inherits="IsTakipSistemiWeb.firma_listesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Firma Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Firma Listesi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">FİRMA LİSTESİ</span>
                                        </div>
                                        <div class="actions">
                                            <a href="/firma_ekle.aspx" class="btn btn-success">Yeni Firma Kaydı</a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="table-toolbar">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    
                                                </div>
                                                <div class="col-md-6">
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <table class="table table-striped table-bordered" id="sample_editable_1">
                                            <thead>
                                                <tr>
                                                    <th> Firma ID </th>
                                                    <th> Cari Kodu </th>
                                                    <th> Durum </th>
                                                    <th> SGK No </th>
                                                    <th> Unvan </th>
                                                    <th> Telefon </th>
                                                    <th> Mail </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptFirmalar" OnItemCommand="RptFirmalar_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <span class="label label-primary label-sm"><%#Eval("firma_id") %></span>  </td>
                                                            <td> <%#Eval("cari_kod") %> </td>
                                                            <td style='<%# "background-color:" + Eval("arkaplan_rengi") + ";" %>'> <%#Eval("durum") %> </td>
                                                            <td> <%#Eval("sgk_no") %> </td>
                                                            <td> <%#Eval("unvan") %> </td>
                                                            <td> <%#Eval("telefon") %> </td>
                                                            <td> <%#Eval("mail") %> </td>
                                                       
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                                
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>
                        </div>                   
                        
    </div>

</asp:Content>
