<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="Internado.Students.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create Student</h1>

<h4>Student</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName">Nombre del Estudiante</asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Apellido</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSecondLastName" runat="server" AssociatedControlID="txtSecondLastName">Segundo Apellido</asp:Label>
            <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone">Teléfono</asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSpeciality" runat="server" AssociatedControlID="txtSpeciality">Especialidad</asp:Label>
            <asp:TextBox ID="txtSpeciality" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDoctor" runat="server" AssociatedControlID="ddlDoctor">Doctor Asignado</asp:Label>
            <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblHospital" runat="server" AssociatedControlID="ddlHospital">Hospital Asignado</asp:Label>
            <asp:DropDownList ID="ddlHospital" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
