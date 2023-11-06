<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ReportStudent.aspx.cs" Inherits="Internado.Reporte.ReportStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <center>
        <h1>Reporte Interno</h1>
    </center>

    <div class="row">
        <div class="col-md-2">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-2">
             <asp:Button runat="server" ID="btnSearch" Text="Buscar" CssClass="btn btn-info" OnClick="btnSearch_Click"/>
        </div>
        <div class="col-md-2">
             <asp:Button runat="server" ID="btnDescargarReporteInterno" Text="Descargar Reporte" CssClass="btn btn-warning" OnClick="btnDescargarReporteInterno_Click" />
        </div>
    </div>


     <asp:GridView ID="gbDatos" runat="server" CssClass="table"> </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
