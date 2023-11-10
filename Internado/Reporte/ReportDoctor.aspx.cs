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
using System.Drawing;
using System.IO;
using System.Web;
using ClosedXML.Excel;


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

        //Reporte General Doctor pdf
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

        //Reporte Por nombre Doctor Pdf
        void exportReportToPdfByName()
        {
            string selectedDoctor = ddlDoctor.SelectedItem.ToString();
            DataTable dt = report.reportDoctorbyName(selectedDoctor);

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

            BaseFont customFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font customTitleFont = new iTextSharp.text.Font(customFont, 15, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);

            PdfPCell headerCell;


            foreach (DataColumn column in dt.Columns)
            {

                headerCell = new PdfPCell(new Phrase(column.ColumnName, customTitleFont));
                headerCell.BackgroundColor = new BaseColor(51, 153, 255);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(headerCell);

            }

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


        //Reporte General Doctor Excel
        void exportReportToExcel()
        {
            string selectedDoctor = ddlDoctor.SelectedItem.ToString();
            DataTable dt = report.reportDoctor();

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Reporte Doctor");

                ws.Cell(1, 1).Value = "Informe de Doctores";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 15;
                ws.Range("A1:G1").Merge();
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = "Nombre Doctor: "+ selectedDoctor;
                ws.Cell(2, 1).Style.Font.Bold = true;
                ws.Cell(2, 1).Style.Font.FontSize = 15;
                ws.Range("A2:G2").Merge();
                ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(3, 1).Value = "Fecha: " + DateTime.Now.ToString();
                ws.Cell(3, 1).Style.Font.Bold = true;
                ws.Cell(3, 1).Style.Font.FontSize = 12;
                ws.Range("A3:G3").Merge();
                ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(5, 1).Value = "Nº";
                ws.Cell(5, 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#808080");
                ws.Cell(5, 1).Style.Font.Bold = true;
                ws.Cell(5, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                for (int i = 2; i <= dt.Columns.Count; i++)
                {
                    ws.Cell(5, i).Value = dt.Columns[i - 2].ColumnName;
                    ws.Cell(5, i).Style.Fill.BackgroundColor = XLColor.FromHtml("#808080");
                    ws.Cell(5, i).Style.Font.Bold = true;
                    ws.Cell(5, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.Cell(i + 6, 1).Value = i + 1;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ws.Cell(i + 6, j + 2).Value = dt.Rows[i][j].ToString();
                    }
                }

                MemoryStream ms = new MemoryStream();
                wb.SaveAs(ms);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteDoctor.xlsx");
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
        }

        //Reporte por nombre Doctor Excel
        void exportReportToExcelByName()
        {
            string selectedDoctor = ddlDoctor.SelectedItem.ToString();
            DataTable dt = report.reportDoctorbyName(selectedDoctor);
            ////DataTable dt = report.reportDoctor();

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Reporte Doctor");

                ws.Cell(1, 1).Value = "Informe de Doctores";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 15;
                ws.Range("A1:G1").Merge();
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = "Nombre Doctor: " + selectedDoctor;
                ws.Cell(2, 1).Style.Font.Bold = true;
                ws.Cell(2, 1).Style.Font.FontSize = 15;
                ws.Range("A2:G2").Merge();
                ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(3, 1).Value = "Fecha: " + DateTime.Now.ToString();
                ws.Cell(3, 1).Style.Font.Bold = true;
                ws.Cell(3, 1).Style.Font.FontSize = 12;
                ws.Range("A3:G3").Merge();
                ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(5, 1).Value = "Nº";
                ws.Cell(5, 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#808080");
                ws.Cell(5, 1).Style.Font.Bold = true;
                ws.Cell(5, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                for (int i = 2; i <= dt.Columns.Count; i++)
                {
                    ws.Cell(5, i).Value = dt.Columns[i - 2].ColumnName;
                    ws.Cell(5, i).Style.Fill.BackgroundColor = XLColor.FromHtml("#808080");
                    ws.Cell(5, i).Style.Font.Bold = true;
                    ws.Cell(5, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // Agregar datos
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.Cell(i + 6, 1).Value = i + 1;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ws.Cell(i + 6, j + 2).Value = dt.Rows[i][j].ToString();
                    }
                }

                MemoryStream ms = new MemoryStream();
                wb.SaveAs(ms);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteDoctor.xlsx");
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            loadReportbyNameDoctor();
        }

        //protected void BtnDescargarReporte_Click(object sender, EventArgs e)
        //{
        //    //exportReportToPDF();
        //    //exportReportToExcel();
        //}

        protected void ddlDescargarPdf_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlDescargarPdf.SelectedItem.Text == "Descarga General")
            {
                exportReportToPDF();
                ddlDescargarPdf.SelectedValue = "Descargar Pdf";
            }
            else
            {
                exportReportToPdfByName();
            }
        }

        protected void ddlDescargarExcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlDescargarExcel.SelectedItem.Text == "Descarga General")
            {
                exportReportToExcel();
            }
            else
            {
                exportReportToExcelByName();
            }
        }
    }
}