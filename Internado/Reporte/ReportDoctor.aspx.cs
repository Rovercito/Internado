using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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

        void exportReportToPDF()
        {
            DataTable dt = report.reportDoctor();

            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();


            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);

            pdfTable.DefaultCell.Border = PdfPCell.BOX;
            pdfTable.DefaultCell.BorderColor = BaseColor.GRAY;
            pdfTable.DefaultCell.BackgroundColor = new BaseColor(230, 230, 230);
            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

            //BaseFont customFont = BaseFont.CreateFont("path-to-custom-font.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont customFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font customTitleFont = new iTextSharp.text.Font(customFont, 15, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
            // customTitleFont = new Font(customFont, 16, Font.BOLD, BaseColor.DARK_GRAY);

            PdfPCell headerCell;


            foreach (DataColumn column in dt.Columns)
            {

                headerCell = new PdfPCell(new Phrase(column.ColumnName, customTitleFont));
                headerCell.BackgroundColor = new BaseColor(51, 153, 255);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(headerCell);

            }

            //doc.Add(new Paragraph("Informe de Doctores", customTitleFont));
            //doc.Add(new Paragraph("Fecha: " + DateTime.Now.ToString(), customTitleFont));

            Paragraph titleParagraph = new Paragraph("Informe de Doctores", customTitleFont);
            titleParagraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(titleParagraph);

            Paragraph dateParagraph = new Paragraph("Fecha: " + DateTime.Now.ToString(), customTitleFont);
            dateParagraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(dateParagraph);

            Paragraph emptySpace = new Paragraph(" ");
            emptySpace.SpacingBefore = 20f;
            doc.Add(emptySpace);



            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString()));
                    pdfTable.AddCell(cell);

                }
            }

            doc.Add(pdfTable);
            doc.Close();

            //descargar
            Response.ContentType = "prueba/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Reporte Doctor.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();

        }


        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            loadReportbyNameDoctor();
        }

        protected void BtnDescargarReporte_Click(object sender, EventArgs e)
        {
            exportReportToPDF();
        }
    }
}