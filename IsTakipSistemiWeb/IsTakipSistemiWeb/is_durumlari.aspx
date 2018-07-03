<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="is_durumlari.aspx.cs" Inherits="IsTakipSistemiWeb.is_durumlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">İş Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>İş Durumları</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">İŞ YÖNETİMİ</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-12">

                                            
                                         
                                            <div class="col-md-4" style="padding-left:0px;">

                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="TxtDurumAd" placeholder="Yeni Durum Adı" CssClass="form-control input-sm"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-md-4" style="padding-left:0px;">

                                                <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-primary btn-sm" Text="Durumu Kaydet" OnClick="BtnKaydet_Click" />

                                            </div>
                                                

                                           

                                        </div>
                                        
                                        

                                    </div>

                                        <div class="row">

                                            
                                            <div class="col-md-12">
                                                
                                                <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                            <thead>
                                                <tr>
                                                    <th> # </th>
                                                    <th> Durum Adı </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptDurumlar">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <%#Eval("durum_id") %> </td>
                                                            <td> <%#Eval("ad") %> </td>
                                                           
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                                
                                            </tbody>
                                        </table>
                                            
                                            </div>

                                        </div>

                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>

                        </div>                   
                        
    </div>

</asp:Content>
