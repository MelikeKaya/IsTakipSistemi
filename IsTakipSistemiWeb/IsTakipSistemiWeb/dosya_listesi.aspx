<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="dosya_listesi.aspx.cs" Inherits="IsTakipSistemiWeb.dosya_listesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Dosyalama Modülü</a><i class="fa fa-circle"></i></li>                  
                <li><span>Dosya Listesi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">ARŞİV DOSYALARI</span>
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
                                                    <th> # </th>
                                                    <th> Kategori </th>
                                                    <th> İlgili Firma </th>
                                                    <th> Başlık </th>
                                                    <th> Yüklenme Tarihi </th>
                                                    <th> İndir </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptDosyalar">
                                                    <ItemTemplate>
                                                        <tr>

                                                            <td><b><%#Eval("dosyaId") %></b></td>
                                                            <td><%#Eval("kategoriAd") %></td>
                                                            <td><%#Eval("FirmaAd") %></td>
                                                            <td><%#Eval("baslik") %></td>
                                                            <td><%#Convert.ToDateTime(Eval("tarih")).ToShortDateString() %></td>
                                                            <td>
                                                                <a class="btn btn-block btn-success" href="/DownloadFile.ashx?filePath=<%#Eval("yol") %>">
                                                                    Dosyayı İndir
                                                                </a>
                                                            </td>
                                                            
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
