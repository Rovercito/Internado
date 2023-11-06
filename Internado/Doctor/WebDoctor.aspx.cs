using DaoInternado.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Doctor
{
    public partial class WebDoctor : System.Web.UI.Page
    {
        DoctorImpl doctorImpl;
        DaoInternado.Model.Doctor doctor;
        int id;
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
            else
            {
                //Response.Redirect("WebLogin.aspx");
            }
        }

        void select()
        {
            try
            {
                doctorImpl = new DoctorImpl();
                DataTable dt = doctorImpl.Select();
                DataTable table = new DataTable("Doctor");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Correo", typeof(string));
                table.Columns.Add("Especialidad", typeof(string));
                table.Columns.Add("Hospital Asignado", typeof(string));
                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                gbDatos.DataSource = table;
                gbDatos.DataBind();


                for (int i = 0; i < gbDatos.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-warning' href='EditDoctor.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i> Editar </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='DeleteDoctor.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i> Eliminar </a>  ";

                    gbDatos.Rows[i].Cells[7].Text = up;
                    gbDatos.Rows[i].Cells[8].Text = del;
                    gbDatos.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCrearDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Doctor/CreateDoctor.aspx");
        }

        protected void BtnReporteDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reporte/ReportDoctor.aspx");
        }
    }
}