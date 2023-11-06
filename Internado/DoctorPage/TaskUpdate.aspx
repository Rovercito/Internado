<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="TaskUpdate.aspx.cs" Inherits="Internado.DoctorPage.TaskUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <h1>MODIFICAR TAREA</h1>

<h4>Actualizacion</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription">Descripcion de la Tarea</asp:Label>
            <asp:TextBox ID="txtDescription" TextMode="DateTime" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAssingDateExpired" runat="server" AssociatedControlID="txtAssingDateExpired">Fecha Limite</asp:Label>
            <asp:TextBox ID="txtAssingDateExpired" TextMode="Date" runat="server" CssClass="table table-condensed"></asp:TextBox>
        </div>
        <hr/>
        <div class="form-group">
            <asp:Button ID="btnUpdate" runat="server" Text="Modificar Asignacion" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
