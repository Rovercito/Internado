<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ReportHospital.aspx.cs" Inherits="Internado.Hospital.ReportHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
        <h1>Reporte</h1>
    </center>

    <div class="row">
        <%--<div class="col-md-2">
           <asp:Label runat="server" Text="Hospital" />
        </div> --%>
        <div class="col-md-2">
            <asp:DropDownList runat="server" ID="ddlFilterHospital" AppendDataBoundItems="false" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlFilterHospital_SelectedIndexChanged">
                    <asp:ListItem Text="Filtrar Hospitales" Value="0" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
             <asp:Button runat="server" ID="btnDescargarReporte" Text="Descargar Reporte" CssClass="btn btn-warning" OnClick="btnDescargarReporte_Click"/>
        </div>
    </div>
    
    
    <div>
        <asp:GridView runat="server" ID="gvReportHospital" CssClass="table" HeaderStyle-BackColor="#b5b5b5" BackColor="#dcdbdc" DataKeyName="ID"></asp:GridView>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
