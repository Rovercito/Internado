<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="CreateStudent.aspx.cs" Inherits="Internado.Students.CreateStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Student</title>
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
                <asp:Label ID="lblControl1" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Apellido</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblControl2" runat="server"></asp:Label>
            
            </div>
            <div class="form-group">
                <asp:Label ID="lblSecondLastName" runat="server" AssociatedControlID="txtSecondLastName">Segundo Apellido</asp:Label>
                <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblControl3" runat="server"></asp:Label>

            </div>
            <div class="form-group">
                <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone">Teléfono</asp:Label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblControl4" runat="server"></asp:Label>

            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblControl5" runat="server"></asp:Label>

            </div>
            <div class="form-group">
                <asp:Label ID="lblSpeciality" runat="server" AssociatedControlID="txtSpeciality">Especialidad</asp:Label>
                <asp:TextBox ID="txtSpeciality" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblControl6" runat="server"></asp:Label>
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
                <asp:Button ID="btnCreate" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
