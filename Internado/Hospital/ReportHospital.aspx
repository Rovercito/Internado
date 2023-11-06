<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ReportHospital.aspx.cs" Inherits="Internado.Hospital.ReportHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>REPORTE</h1>

    <div>
        <asp:DropDownList runat="server" ID="ddlFilterHospital" AppendDataBoundItems="false" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlFilterHospital_SelectedIndexChanged">
            
        </asp:DropDownList>
    </div>
    <div>
        <asp:GridView runat="server" ID="gvReportHospital" CssClass="table" class="table table-dark" DataKeyName="ID"></asp:GridView>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
