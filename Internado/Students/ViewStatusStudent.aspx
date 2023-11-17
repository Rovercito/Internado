<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ViewStatusStudent.aspx.cs" Inherits="Internado.Students.ViewStatusStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center><h1>Tarea de Internos</h1></center>

   <div class="container mt-3">
        <div class="row">
            <div class="col-md-3">
                <label for="txtStartDate" class="form-label text-white">Sin texto</label>
                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Busqueda por Nombre" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <%--<label for="txtStartDate" class="form-label">Fecha de Inicio:</label>
                <input type="date" id="txtStartDate" class="form-control">--%>
                <label for="txtStartDate" class="form-label">Fecha de Inicio:</label>
                <asp:TextBox ID="TxbStarDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

            </div>
            <div class="col-md-2">
                <%--<label for="txtEndDate" class="form-label">Fecha de Fin:</label>
                <input type="date" id="txtEndDate" class="form-control">--%>
                <label for="txtEndDate" class="form-label">Fecha de Inicio:</label>
                <asp:TextBox ID="TxbEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

            </div>
            <div class="col-md-1">
                <label class="font-weight-bold">&nbsp;</label>
                <asp:Button ID="btnFilter" runat="server" Text="Filtrar" CssClass="btn btn-primary form-control" OnClick="btnFilter_Click" />
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-3">
                <label class="font-weight-bold">&nbsp;</label>
                 <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged">
                    <asp:ListItem Text="Filtrar Tareas" Value="0" />
                    <asp:ListItem Text="Pendiente" Value="1" />
                    <asp:ListItem Text="Aceptada" Value="2" />
                    <asp:ListItem Text="Terminada" Value="3" />
                    <asp:ListItem Text="Rechazada" Value="4" />
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <br />


     <asp:Literal ID="LiteralTable" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
