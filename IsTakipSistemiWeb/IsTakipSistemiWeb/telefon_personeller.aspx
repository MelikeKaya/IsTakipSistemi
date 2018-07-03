<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="telefon_personeller.aspx.cs" Inherits="IsTakipSistemiWeb.telefon_personeller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İletişim Modülü</a><i class="fa fa-circle"></i></li>                  
                <li><span>Personel Telefon Rehberi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">TELEFON REHBERİ</span>
                                        </div>
                                        <div class="actions">
                                            
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
                                        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                            <thead>
                                                <tr>
                                                    <th> T.C.Kimlik </th>
                                                    <th> Departman </th>
                                                    <th> Ad & Soyad </th>
                                                    <th> Telefon </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptRehber">
                                                    <ItemTemplate>
                                                        <tr>

                                                            <td> <b><%#Eval("tc") %></b> </td>
                                                            <td> <%#Eval("departman") %> </td>
                                                            <td> <%#Eval("adsoyad") %> </td>
                                                            <td> <%#Eval("telefon") %> </td>
                                                            
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
