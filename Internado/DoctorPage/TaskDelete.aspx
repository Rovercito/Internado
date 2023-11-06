<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="TaskDelete.aspx.cs" Inherits="Internado.DoctorPage.TaskDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Eliminar Tarea Asignada</h1>

 
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="lblDescripcion" runat="server">Descripcion de la Tarea Asignada</asp:Label>
            <asp:Label ID="lblDescripcionValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAssingDate" runat="server" AssociatedControlID="txtAssingDate">Fecha Inicio</asp:Label>
            <asp:TextBox ID="txtAssingDate" TextMode="Date" runat="server" CssClass="table table-condensed"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAssingDateExpired" runat="server" AssociatedControlID="txtAssingDateExpired">Fecha Limite</asp:Label>
            <asp:TextBox ID="txtAssingDateExpired" TextMode="Date" runat="server" CssClass="table table-condensed"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblStudent" runat="server" AssociatedControlID="cmbStudent">Estudiante</asp:Label>
            <asp:DropDownList ID="cmbStudent" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnDeleteTask" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnDeleteTask_Click" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
