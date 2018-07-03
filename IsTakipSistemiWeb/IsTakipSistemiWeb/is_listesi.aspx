<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="is_listesi.aspx.cs" Inherits="IsTakipSistemiWeb.is_listesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İş Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>İş Listesi</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">İŞ LİSTESİ</span>
                                        </div>
                                        <div class="actions">
                                            <a href="/is_kaydi.aspx" class="btn btn-success">Yeni İş Kaydı</a>
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
                                                    <th> Firma </th>
                                                    <th> Başlık </th>
                                                    <th> Tür </th>
                                                    <th> Durum </th>
                                                    <th> Kayıt Tarihi </th>
                                                    <th> İşlem </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptIsler" OnItemCommand="RptIsler_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <%#Eval("is_id") %> </td>
                                                            <td> <%#Eval("firma_unvan") %> </td>
                                                            <td> <%#Eval("baslik") %> </td>
                                                            <td> <%#Eval("tur_adi") %> </td>
                                                            <td> <%#Eval("durum_adi") %> </td>
                                                            <td> <%#Convert.ToDateTime(Eval("kayit_tarih")).ToShortDateString() %> </td>
                                                            <td> 
                                                                <asp:LinkButton runat="server" CommandName="Detay" CommandArgument='<%#Eval("is_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="İş Detayına Bak"><i class="fa fa-info"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="Atama" CommandArgument='<%#Eval("is_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="Atamaları İncele"><i class="fa fa-tasks"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="AltIs" CommandArgument='<%#Eval("is_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="Alt İşleri İncele"><i class="fa fa-eye"></i></asp:LinkButton>
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


