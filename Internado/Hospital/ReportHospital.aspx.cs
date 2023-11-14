using DaoInternado.Implementation;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Hospital
{
    public partial class ReportHospital : System.Web.UI.Page
    {
        HospitalImpl hospitalIMPL;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("~/Logout.aspx");
            }
            else
            {
                //Response.Redirect("WebLogin.aspx");
            }
            ShowReport();
            ShowHospital();
        }

        private void ShowHospital()
        {
            hospitalIMPL = new HospitalImpl();
            try
            {
                ddlFilterHospital.DataSource = hospitalIMPL.LoadComboBoxHospital();
               
                ddlFilterHospital.DataTextField = "name";
                ddlFilterHospital.DataValueField = "idHospital";

               
                
                ddlFilterHospital.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ShowReport()
        {
            try
            {
                try
                {
                    hospitalIMPL = new HospitalImpl();
                    DataTable dt = hospitalIMPL.SelectReport();
                    DataTable table = new DataTable("ReportHospital");
                    table.Columns.Add("Hospital", typeof(string));
                    table.Columns.Add("Direccion", typeof(string));
                    table.Columns.Add("Telefono", typeof(string));
                    table.Columns.Add("Correo Electronico", typeof(string));
                    table.Columns.Add("Doctor Cabezera", typeof(string));
                    table.Columns.Add("Total Estudiantes", typeof(int));

                    foreach (DataRow dr in dt.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    gvReportHospital.DataSource = table;
                    gvReportHospital.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetShowReport(int id)
        {
            try
            {
                try
                {
                    hospitalIMPL = new HospitalImpl();
                    DataTable dt = hospitalIMPL.GetReportHospital(id);
                    DataTable table = new DataTable("ReportHospital");
                    table.Columns.Add("Hospital", typeof(string));
                    table.Columns.Add("Direccion", typeof(string));
                    table.Columns.Add("Telefono", typeof(string));
                    table.Columns.Add("Correo Electronico", typeof(string));
                    table.Columns.Add("Doctor Cabezera", typeof(string));
                    table.Columns.Add("Total Estudiantes", typeof(int));

                    foreach (DataRow dr in dt.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    gvReportHospital.DataSource = table;
                    gvReportHospital.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void exportReportToPDF()
        {
            DataTable dt = hospitalIMPL.SelectReport();

            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);

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

            Paragraph titleParagraph = new Paragraph("Informe de Hospital", customTitleFont);
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
            Response.AddHeader("content-disposition", "attachment;filename=Reporte Hospital.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }


        protected void ddlFilterHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            id = int.Parse(ddlFilterHospital.SelectedValue);
            GetShowReport(id);
        }

        protected void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            exportReportToPDF();
        }
    }
}