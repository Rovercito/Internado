using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Model;
using DaoInternado.Implementation;
using System.Data;

namespace Internado
{
    public partial class WebStudent : System.Web.UI.Page
    {
        StudentImpl implStudent;
        Student S;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }


        void Select()
        {
            try
            {
                implStudent = new StudentImpl();
                DataTable dt = implStudent.Select();
                DataTable table = new DataTable("Student");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Correo", typeof(string));

                table.Columns.Add("Especialidad", typeof(string));
                table.Columns.Add("Doctor Asignado", typeof(string));
                table.Columns.Add("Hospital Asignado", typeof(string));
                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }

                GridData.DataSource = table;
                GridData.DataBind();

                for (int i = 0; i < GridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-warning' href='EditStudent.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i> Editar </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='DeleteStudent.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i> Eliminar </a>  ";

                    GridData.Rows[i].Cells[8].Text = up;
                    GridData.Rows[i].Cells[9].Text = del;
                    GridData.Rows[i].Attributes["data-id"] = id;
                }   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCrearInterno_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Students/CreateStudent.aspx");
        }

        protected void btnVerTareaInterno_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Students/ViewStatusStudent.aspx");
        }

        protected void btnReporteInterno_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reporte/ReportStudent.aspx");
        }
    }
}