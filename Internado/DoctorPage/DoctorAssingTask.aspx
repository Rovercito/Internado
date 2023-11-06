<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DoctorAssingTask.aspx.cs" Inherits="Internado.DoctorPage.DoctorAssingTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>A S I G N A C I O N   D E   T A R E A</h1>

<h4>Asignar - Tarea</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription">Descripcion</asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
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
            <asp:Label ID="lblStudent" runat="server" AssociatedControlID="cmbStudent">Estudiantes</asp:Label>
            <asp:DropDownList ID="cmbStudent" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <hr/>
        <div class="form-group">
            <asp:Button ID="btnCreate" runat="server" Text="Asignar Tarea" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
