<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="IndexHospital.aspx.cs" Inherits="Internado.Hospital.IndexHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Index</h1>

    <p>
        <a class="nav-link text-dark" style="font-size:x-large;  text-align: left" href="/Hospital/CreateHospital.aspx">Registrar Nuevo Hospital</a>
    </p>
    <p>
    <a class="btn btn-sm btn-warning" style="font-size:x-large;  text-align: left" href="/Hospital/ReportHospital.aspx">Reporte</a>
    </p>

<asp:GridView ID="GridDataHospital" runat="server" CssClass="table" class="table table-dark" DataKeyName="ID">
   <%-- <Columns>
        <asp:TemplateField HeaderText="Opciones">
            <ItemTemplate>
                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" Text="Editar" runat="server" class="btn btn-success" />
                <asp:Button ID="btnDelete" OnClick="btnDelete_Click" Text="Eliminar" runat="server" class="btn btn-warning" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>--%>
</asp:GridView>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
