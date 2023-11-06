using DaoInternado.Implementation;
using DaoInternado.Model;
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

namespace Internado.Reporte
{
    public partial class ReportStudent : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
        protected void Page_Load(object sender, EventArgs e)
        {
            select();


            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

        void select()
        {
            try
            {
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.ReportStudent();
                DataTable table = new DataTable("TaskStudent");
                table.Columns.Add("Estudiante Asignado", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Estado Tarea", typeof(string));
                table.Columns.Add("Doctor Asignado", typeof(string));
                table.Columns.Add("Hospital Asignado", typeof(string));
                table.Columns.Add("Tarear Terminadas", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
                gbDatos.DataSource = table;
                gbDatos.DataBind();


                for (int i = 0; i < gbDatos.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    //string up = " <a class='btn btn-sm btn-warning' href='EditDoctor.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i> Editar </a> ";
                    //string del = " <a class='btn btn-sm btn-danger' href='DeleteDoctor.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i> Eliminar </a>  ";

                    //gbDatos.Rows[i].Cells[7].Text = up;
                    //gbDatos.Rows[i].Cells[8].Text = del;
                    gbDatos.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void exportReportbyPDF()
        {
            DataTable dt = implTask.ReportStudent();

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

            Paragraph titleParagraph = new Paragraph("Informe de Internos", customTitleFont);
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
            Response.AddHeader("content-disposition", "attachment;filename=Reporte Internos.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }

        void selectbyName(string name)
        {
            try
            {
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.selectbyName(name);

                DataTable table = new DataTable("TaskStudent");
                table.Columns.Add("Estudiante Asignado", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Estado Tarea", typeof(string));
                table.Columns.Add("Doctor Asignado", typeof(string));
                table.Columns.Add("Hospital Asignado", typeof(string));
                table.Columns.Add("Tareas Terminadas", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }

                gbDatos.DataSource = table;
                gbDatos.DataBind();

                for (int i = 0; i < gbDatos.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    gbDatos.Rows[i].Attributes["data-id"] = id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text.Trim();

            if(name != "")
            {
                selectbyName(name);
            }
            else
            {
                select();
            }

            //selectbyName(name);
        }

        protected void btnDescargarReporteInterno_Click(object sender, EventArgs e)
        {
            exportReportbyPDF();
        }
    }
}