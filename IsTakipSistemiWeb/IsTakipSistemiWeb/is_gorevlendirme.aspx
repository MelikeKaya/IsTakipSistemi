<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="is_gorevlendirme.aspx.cs" Inherits="IsTakipSistemiWeb.is_gorevlendirme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İş Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Görevlendirmeler</span></li>                    
            </ul>                   
        </div>        
        <br />  

        <div class="row">
                            <div class="col-md-12">
                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                <div class="portlet light portlet-fit bordered">
                                    <div class="portlet-title">

                                            <div class="col-sm-8"><asp:DropDownList runat="server" CssClass="form-control input-sm" AutoPostBack="true" ID="DrpIsler"></asp:DropDownList></div>
                                            <div class="col-sm-4"><asp:Button runat="server" ID="BtnSorgula" Text="Görev Sorgula" OnClick="BtnSorgula_Click" CssClass="btn btn-success btn-sm" /></div>
                
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
                                                    <th> İş Başlığı </th>
                                                    <th> Atanan Personel </th>
                                                    <th> Başlangıç Tarihi </th>
                                                    <th> Görev Tanımı </th>
                                                    <th> İşlem </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptGorevlendirme">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <%#Eval("kayit_id") %> </td>
                                                            <td> <%#Eval("isBaslik") %> </td>
                                                            <td> <%#Eval("personelAdSoyad") %> </td>                                                            
                                                            <td> <%#Convert.ToDateTime(Eval("baslangic")).ToShortDateString() %> </td>
                                                            <td> <%#Eval("aciklama") %> </td>
                                                            <td> 
                                                                <asp:LinkButton runat="server" CommandName="Detay" CommandArgument='<%#Eval("kayit_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="İş Detayına Bak"><i class="fa fa-info"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="Atama" CommandArgument='<%#Eval("kayit_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="Atamaları İncele"><i class="fa fa-tasks"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" CommandName="AltIs" CommandArgument='<%#Eval("kayit_id") %>' CssClass="btn btn-icon-only btn-default tooltips" data-container="body" data-placement="top" data-original-title="Alt İşleri İncele"><i class="fa fa-eye"></i></asp:LinkButton>
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
