<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ReportDoctor.aspx.cs" Inherits="Internado.Reporte.ReportDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-2">
            <label id="lbl" runat="server" for="ddlEstados">Nombre Doctor</label>
        </div>
        
        <div class="col-md-2">
            <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged">
                <asp:ListItem Text="Filtrar Tareas" Value="0" />
            </asp:DropDownList>
        </div>
        <%--<div class="col-md-2">
            <asp:Button runat="server" ID="BtnDescargarReporte" Text="Descargar Reporte" CssClass="btn btn-warning" OnClick="BtnDescargarReporte_Click"/>
        </div>--%>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlDescargarPdf" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDescargarPdf_SelectedIndexChanged">
                <asp:ListItem Text="Descargar Pdf" Value="0" />
                <asp:ListItem Text="Descarga General" Value="1" />
                <asp:ListItem Text="Descargar Por Nombre" Value="2" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="ddlDescargarExcel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDescargarExcel_SelectedIndexChanged">
                <asp:ListItem Text="Descargar Excel" Value="0" />
                <asp:ListItem Text="Descarga General" Value="1" />
                <asp:ListItem Text="Descargar Por Nombre" Value="2" />
            </asp:DropDownList>
        </div>
        
    
    </div>

    <br />


    <div class="container container-lg container-md">
    <asp:Literal ID="LiteralTable" runat="server"></asp:Literal>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
