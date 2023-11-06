<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="WebStudent.aspx.cs" Inherits="Internado.WebStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Index</h1>

    <p>
    <a class="nav-link text-dark" style="font-size: x-large; vertical-align: top; text-align: left" href="CreateStudent.aspx">Crear Nuevo Interinos</a>
    <a class="nav-link text-dark" style="font-size: x-large; vertical-align: top; text-align: center" href="ViewStatusStudent.aspx">Ver Tareas de los Interinos</a>
</p>
    <p>
        <a class="btn btn-sm btn-warning" style="font-size:x-large;  text-align: left" href="../Reporte/ReportStudent.aspx">Reporte</a>
    </p>

    <asp:GridView ID="GridData" runat="server" CssClass="table">
       
    </asp:GridView>
</asp:Content>