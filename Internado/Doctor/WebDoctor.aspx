<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="WebDoctor.aspx.cs" Inherits="Internado.Doctor.WebDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <center>
       <h1>Lista Doctor</h1>
   </center>
    <br />
     <asp:Button runat="server" ID="btnCrearDoctor" Text="Nuevo Doctor" CssClass="btn btn-info" OnClick="btnCrearDoctor_Click"/>
    <asp:Button runat="server" ID="BtnReporteDoctor" Text="Reporte" CssClass="btn btn-warning" OnClick="BtnReporteDoctor_Click"/>
    <br />
     <asp:GridView ID="gbDatos" runat="server" CssClass="table" HeaderStyle-BackColor="#b5b5b5" BackColor="#dcdbdc"> </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
