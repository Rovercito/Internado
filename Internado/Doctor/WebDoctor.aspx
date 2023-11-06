<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="WebDoctor.aspx.cs" Inherits="Internado.Doctor.WebDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   

     <asp:Button runat="server" ID="btnCrearDoctor" Text="+ Nuevo" CssClass="btn btn-primary" OnClick="btnCrearDoctor_Click" data-toggle="fomrDoctor" data-target="#nuevoDoctor"/>
     <asp:GridView ID="gbDatos" runat="server" CssClass="table"> </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
