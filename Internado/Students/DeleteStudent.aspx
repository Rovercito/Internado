<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="Internado.Students.DeleteStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Eliminar Interno</h1>

<%--<h4>Student</h4>--%>
<hr />
<div class="row">
    <div class="col-md-4">
        <div class="form-group">
            <asp:Label ID="lblName" runat="server">Nombre del Estudiante</asp:Label>
            <asp:Label ID="lblNameValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblLastName" runat="server">Apellido</asp:Label>
            <asp:Label ID="lblLastNameValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSecondLastName" runat="server">Segundo Apellido</asp:Label>
            <asp:Label ID="lblSecondLastNameValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server">Teléfono</asp:Label>
            <asp:Label ID="lblPhoneValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server">Email</asp:Label>
            <asp:Label ID="lblEmailValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSpeciality" runat="server">Especialidad</asp:Label>
            <asp:Label ID="lblSpecialityValue" runat="server" CssClass="form-control"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDoctor" runat="server">Doctor Asignado</asp:Label>
            <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblHospital" runat="server">Hospital Asignado</asp:Label>
            <asp:DropDownList ID="ddlHospital" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnDelete_Click" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
