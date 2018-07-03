<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="personel_listesi.aspx.cs" Inherits="IsTakipSistemiWeb.personel_listesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Personel Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Personel Listesi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">PERSONEL LİSTESİ</span>
                                        </div>
                                        <div class="actions">
                                            <a href="/personel_ekle.aspx" class="btn btn-success">Yeni Personel Kaydı</a>
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
                                                    <th> T.C. Kimlik </th>
                                                    <th> Ad & Soyad </th>
                                                    <th> Departman </th>
                                                    <th> Unvan </th>
                                                    <th> Cinsiyet </th>
                                                    <th> Telefon </th>
                                                    <th> Mail </th>
                                                    <th> İşlem </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptPersoneller" OnItemCommand="RptPersoneller_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <b><%#Eval("tc") %></b> </td>
                                                            <td> <%#Eval("adsoyad") %> </td>
                                                            <td> <%#Eval("departman") %> </td>
                                                            <td> <%#Eval("unvan") %> </td>
                                                            <td> <%#Eval("cinsiyet") %> </td>
                                                            <td> <%#Eval("telefon") %> </td>
                                                            <td> <%#Eval("mail") %> </td>
                                                            <td> 
                                                                <asp:LinkButton runat="server" CommandName="Detay" CommandArgument='<%#Eval("tc") %>' CssClass="btn btn-icon-only btn-default tooltips btn-sm" data-container="body" data-placement="top" data-original-title="Detaya Git"><i class="fa fa-user"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="Gorev" CommandArgument='<%#Eval("tc") %>' CssClass="btn btn-icon-only btn-default tooltips btn-sm" data-container="body" data-placement="top" data-original-title="Görevlendirme"><i class="fa fa-tasks"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="Sil" CommandArgument='<%#Eval("tc") %>' CssClass="btn btn-icon-only btn-default tooltips btn-sm" data-container="body" data-placement="top" data-original-title="Sil"><i class="fa fa-times"></i></asp:LinkButton>
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
