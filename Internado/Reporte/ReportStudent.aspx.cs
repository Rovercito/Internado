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
    }
}