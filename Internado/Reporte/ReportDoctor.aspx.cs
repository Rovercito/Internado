using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Reporte
{
    public partial class ReportDoctor : System.Web.UI.Page
    {
        ReportImpl report;

        StudentImpl implStudent;

        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            doctorAllCombo();
            loadReportDoctor();
        }

        void doctorAllCombo()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBox();
                    implStudent = new StudentImpl();
                    ddlDoctor.DataSource = combo;
                    ddlDoctor.DataTextField = "name";
                    ddlDoctor.DataValueField = "id";
                    //Brand.DataSource = combo.DefaultView;
                    ddlDoctor.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        void loadReportDoctor()
        {
            try
            {
                //string selectedDoctor = ddlDoctor.SelectedItem.ToString();
                report = new ReportImpl();
                DataTable dt = report.reportDoctor();

                StringBuilder tableHtml = new StringBuilder();
                tableHtml.Append("<table class='table table-bordered table-striped'>");
                tableHtml.Append("<thead>");
                tableHtml.Append("<tr>");
                tableHtml.Append("<th>Doctor</th>");
                tableHtml.Append("<th>Estudiante</th>");
                tableHtml.Append("<th>Hospital</th>");
                tableHtml.Append("<th>Estado</th>");
                tableHtml.Append("<th>Descripción</th>");
                tableHtml.Append("<th>Imagen</th>");
                tableHtml.Append("<th>Archivo</th>");
                tableHtml.Append("</tr>");
                tableHtml.Append("</thead>");
                tableHtml.Append("<tbody>");

                foreach (DataRow dr in dt.Rows)
                {
                    string Doctor = dr["Doctor"].ToString();
                    string Estudiante = dr["Estudiante"].ToString();
                    string Hospital = dr["Hospital"].ToString();
                    string Estado = dr["Estado"].ToString();
                    string Descripción = dr["Descripción"].ToString();
                    string Imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
                    string Archivo = dr["Archivo"] != DBNull.Value ? "data:application/pdf;base64," + Convert.ToBase64String((byte[])dr["Archivo"]) : "";

                    tableHtml.Append("<tr>");
                    tableHtml.Append($"<td>{Doctor}</td>");
                    tableHtml.Append($"<td>{Estudiante}</td>");
                    tableHtml.Append($"<td>{Hospital}</td>");
                    tableHtml.Append($"<td>{Estado}</td>");
                    tableHtml.Append($"<td>{Descripción}</td>");
                    tableHtml.Append($"<td><img src='{Imagen}' alt='Imagen'  style='max-width:70px; max-height:70px;' /></td>");
                    tableHtml.Append($"<td><a href='{Archivo}' download>Descargar PDF</a></td>");
                    tableHtml.Append("</tr>");
                }

                tableHtml.Append("</tbody>");
                tableHtml.Append("</table>");

                LiteralTable.Text = tableHtml.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void loadReportbyNameDoctor()
        {
            try
            {
                string selectedDoctor = ddlDoctor.SelectedItem.ToString();
                report = new ReportImpl();
                DataTable dt = report.reportDoctorbyName(selectedDoctor);

                StringBuilder tableHtml = new StringBuilder();
                tableHtml.Append("<table class='table table-bordered table-striped'>");
                tableHtml.Append("<thead>");
                tableHtml.Append("<tr>");
                tableHtml.Append("<th>Doctor</th>");
                tableHtml.Append("<th>Estudiante</th>");
                tableHtml.Append("<th>Hospital</th>");
                tableHtml.Append("<th>Estado</th>");
                tableHtml.Append("<th>Descripción</th>");
                tableHtml.Append("<th>Imagen</th>");
                tableHtml.Append("<th>Archivo</th>");
                tableHtml.Append("</tr>");
                tableHtml.Append("</thead>");
                tableHtml.Append("<tbody>");

                foreach (DataRow dr in dt.Rows)
                {
                    string Doctor = dr["Doctor"].ToString();
                    string Estudiante = dr["Estudiante"].ToString();
                    string Hospital = dr["Hospital"].ToString();
                    string Estado = dr["Estado"].ToString();
                    string Descripción = dr["Descripción"].ToString();
                    string Imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
                    string Archivo = dr["Archivo"] != DBNull.Value ? "data:application/pdf;base64," + Convert.ToBase64String((byte[])dr["Archivo"]) : "";

                    tableHtml.Append("<tr>");
                    tableHtml.Append($"<td>{Doctor}</td>");
                    tableHtml.Append($"<td>{Estudiante}</td>");
                    tableHtml.Append($"<td>{Hospital}</td>");
                    tableHtml.Append($"<td>{Estado}</td>");
                    tableHtml.Append($"<td>{Descripción}</td>");
                    tableHtml.Append($"<td><img src='{Imagen}' alt='Imagen'  style='max-width:70px; max-height:70px;' /></td>");
                    tableHtml.Append($"<td><a href='{Archivo}' download>Descargar PDF</a></td>");
                    tableHtml.Append("</tr>");
                }

                tableHtml.Append("</tbody>");
                tableHtml.Append("</table>");

                LiteralTable.Text = tableHtml.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            loadReportbyNameDoctor();
        }
    }
}