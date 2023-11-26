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

namespace Internado.StudentPage
{
    public partial class CompletedTasks : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            id = int.Parse(Request.QueryString["id"]);
            lblUsername.Text = (Session["users"].ToString());

            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Estudiante")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }


        void Select()
        {
            try
            {
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.SelectCompletedTask(int.Parse(Session["idPerson"].ToString()));
                if (dt.Rows.Count <= 0)
                {
                    StringBuilder tableHtml2 = new StringBuilder();
                    tableHtml2.Append("<h1>No hay Tareas pendientes</h1>");
                    LiteralTable.Text = tableHtml2.ToString();
                }
                else
                {
                    StringBuilder tableHtml = new StringBuilder();
                    tableHtml.Append("<table class='table'>");
                    tableHtml.Append("<tr>");
                    tableHtml.Append("<th>Descripcion</th>");
                    tableHtml.Append("<th>Fecha</th>");
                    tableHtml.Append("<th>Fecha de Expiracion</th>");
                    tableHtml.Append("<th>Imagen</th>");
                    tableHtml.Append("<th>Archivo</th>");
                    tableHtml.Append("<th>Estado Tarea</th>");
                    tableHtml.Append("<th>Doctor Asignado</th>");
                    tableHtml.Append("<th>Estudiante Asignado</th>");
                    //tableHtml.Append("<th>Ver</th>");
                    //tableHtml.Append("<th>Rechazar</th>");
                    tableHtml.Append("</tr>");

                    foreach (DataRow dr in dt.Rows)
                    {
                        string descripcion = dr["Descripcion"].ToString();
                        string fecha = dr["Fecha"].ToString();
                        string fechaExpiracion = dr["Fecha de Expiracion"].ToString();
                        string imagen = dr["Imagen"] != DBNull.Value? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]): "/Images/logo.png";

                        string archivo = dr["Archivo"] != DBNull.Value ? "data:application/pdf;base64," + Convert.ToBase64String((byte[])dr["Archivo"]) : "";
                        string estadoTarea = dr["Estado Tarea"].ToString();
                        string doctorAsignado = dr["Doctor Asignado"].ToString();
                        string estudianteAsignado = dr["Estudiante Asignado"].ToString();
                        string id = dr["idTaskStudent"].ToString();

                        tableHtml.Append("<tr>");
                        tableHtml.Append($"<td>{descripcion}</td>");
                        tableHtml.Append($"<td>{fecha}</td>");
                        tableHtml.Append($"<td>{fechaExpiracion}</td>");
                        tableHtml.Append($"<td><img src='{imagen}' alt='Imagen'  style='max-width:70px; max-height:70px;' /></td>");
                        tableHtml.Append($"<td><a href='{archivo}' download>Descargar PDF</a></td>");
                        tableHtml.Append($"<td>{estadoTarea}</td>");
                        tableHtml.Append($"<td>{doctorAsignado}</td>");
                        tableHtml.Append($"<td>{estudianteAsignado}</td>");
                        //tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='TaskDetails.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i>Ver</a></td>");
                        //tableHtml.Append($"<td><a class='btn btn-sm btn-danger' href='TaskDetails.aspx?id={id}&type=D'><i class='fas fa-trash' style='background:#FF0000;'></i>Rechazar</a></td>");
                        tableHtml.Append("</tr>");
                    }
                    tableHtml.Append("</table>");

                    LiteralTable.Text = tableHtml.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}