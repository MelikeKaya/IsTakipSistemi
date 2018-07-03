<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="ziyaret_listesi.aspx.cs" Inherits="IsTakipSistemiWeb.ziyaret_listesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('#sample_editable_1').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Ziyaret Listesi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Tüm Ziyaretler</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">ZİYARET LİSTESİ</span>
                                        </div>
                                        <div class="actions">
                                            <a href="/ziyaret_kaydi.aspx" class="btn btn-success">Yeni Ziyaret Kaydı</a>
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
                                                    <th> Tür </th>
                                                    <th> Personel </th>
                                                    <th> Giriş Tarihi </th>
                                                    <th> Ziyaret Saati </th>
                                                    <%--<th> Çıkış Tarihi </th>--%>
                                                    <th> Giriş Uzaklığı </th>
                                                  <%--  <th> Çıkış Uzaklığı </th>--%>
                                                    <th> İşlem </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptZiyaretler" OnItemCommand="RptZiyaretler_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <%#Eval("ziyaretId") %> </td>
                                                            <td> <%#Eval("firma") %> </td>
                                                            <td> <%#Eval("tur") %> </td>
                                                            <td> <%#Eval("personelAdSoyad") %> </td>
                                                            <td> <%#Convert.ToDateTime(Eval("girisTarih")).ToShortDateString() %> </td>
                                                            <td> <%#string.Format("{0:hh\\:mm}", Eval("saat")) %> </td>
                                                          <%--  <td> <%#Eval("cikisTarih") %> </td>--%>
                                                            <td> <%#Eval("girisUzaklik") %> Metre Uzaklıkta </td>
                                                      <%--      <td> <%#Eval("cikisUzaklik") %> Metre Uzaklıkta </td>--%>
                                                            <td> 
                                                               <asp:LinkButton runat="server" CommandName="Detay" CommandArgument='<%#Eval("ziyaretId") %>'>İncele</asp:LinkButton>
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
