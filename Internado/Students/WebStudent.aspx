<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="WebStudent.aspx.cs" Inherits="Internado.WebStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Lista Internos</h1>
    </center>
  <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button runat="server" ID="btnCrearInterno" Text="Nuevo Interno" CssClass="btn btn-info" OnClick="btnCrearInterno_Click"/>
        </div>
        <div class="col-md-2">
            <asp:Button runat="server" ID="btnVerTareaInterno" Text="Ver Terea" CssClass="btn btn-primary" OnClick="btnVerTareaInterno_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button runat="server" ID="btnReporteInterno" Text="Reporte" CssClass="btn btn-warning" OnClick="btnReporteInterno_Click" />
        </div>
    </div>
    <br />

    <asp:GridView ID="GridData" runat="server" CssClass="table" HeaderStyle-BackColor="#b5b5b5" BackColor="#dcdbdc" DataKeyName="ID">
       
    </asp:GridView>
</asp:Content>