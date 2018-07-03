<%@ Page Title="" Language="C#" MasterPageFile="~/MstAna.Master" AutoEventWireup="true" CodeBehind="personel_tipleri.aspx.cs" Inherits="IsTakipSistemiWeb.personel_tipleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-content">

        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li><a href="index.html">Anasayfa</a><i class="fa fa-circle"></i></li>
                <li><a href="#">Personel Yönetimi</a><i class="fa fa-circle"></i></li>                  
                <li><span>Personel Tipleri</span></li>                    
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
                                            <span class="caption-subject font-red sbold uppercase">PERSONEL TİPLERİ</span>
                                        </div>
                                        <div class="actions">
                                            
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                        <div class="col-md-12">

                                            
                                         
                                            <div class="col-md-4" style="padding-left:0px;">

                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="TxtTipAd" placeholder="Yeni Tip Adı" CssClass="form-control input-sm"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-md-4" style="padding-left:0px;">

                                                <asp:Button runat="server" ID="BtnKaydet" CssClass="btn btn-primary btn-sm" Text="Personel Tipini Kaydet" OnClick="BtnKaydet_Click" />

                                            </div>
                                                

                                           

                                        </div>
                                        
                                        

                                    </div>

                                        <div class="row">

                                            
                                            <div class="col-md-12">
                                                
                                                <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
                                            <thead>
                                                <tr>
                                                    <th> # </th>
                                                    <th> Tip Adı </th>
                                                </tr>
                                            </thead>
                                            <tbody>


                                                <asp:Repeater runat="server" ID="RptTipler">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td> <%#Eval("tip_id") %> </td>
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
