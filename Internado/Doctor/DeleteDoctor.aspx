<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DeleteDoctor.aspx.cs" Inherits="Internado.Doctor.DeleteDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Eliminar Doctor</h1>

 
     <div class="row">
         <div class="col-md-4">
             <div class="form-group">
                 <asp:Label ID="lblName" runat="server">Nombre del Doctor</asp:Label>
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
                 <asp:Label ID="cbxHospital" runat="server">Hospital Asignado</asp:Label>
                 <asp:DropDownList ID="cbHospital" runat="server" CssClass="form-control"></asp:DropDownList>
             </div>
             <div class="form-group">
                 <asp:Button ID="btnDeleteDoctor" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnDeleteDoctor_Click" />
             </div>
         </div>
     </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
