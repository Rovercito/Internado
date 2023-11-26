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
    public partial class StudentPage : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();

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
                DataTable dt = implTask.SelectStudent(int.Parse(Session["idPerson"].ToString()));
                if (dt.Rows.Count <= 0)
                {
                    StringBuilder tableHtml2 = new StringBuilder();
                    tableHtml2.Append("<center><h1>No hay Tareas pendientes</h1></center>");
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
                    tableHtml.Append("<th>Ver</th>");
                    tableHtml.Append("<th>Rechazar</th>");
                    tableHtml.Append("</tr>");

                    foreach (DataRow dr in dt.Rows)
                    {
                        string descripcion = dr["Descripcion"].ToString();
                        string fecha = dr["Fecha"].ToString();
                        string fechaExpiracion = dr["Fecha de Expiracion"].ToString();
                        string imagen = dr["Imagen"] != DBNull.Value? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]): "/Images/logo.png";

                        //string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
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
                        tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='TaskDetails.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i>Ver</a></td>");
                        tableHtml.Append($"<td><a class='btn btn-sm btn-danger' href='TaskDetails.aspx?id={id}&type=D'><i class='fas fa-trash' style='background:#FF0000;'></i>Rechazar</a></td>");
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



        /*void Select()
        {
            try
            {
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.SelectStudent(int.Parse(Session["idPerson"].ToString()));
                DataTable table = new DataTable("TaskStudent");
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Fecha", typeof(string));
                table.Columns.Add("Fecha de Expiracion", typeof(string));
                table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Archivo", typeof(string));
                table.Columns.Add("Estado Tarea", typeof(string));
                table.Columns.Add("Doctor Asignado", typeof(string));
                table.Columns.Add("Estudiante Asignado", typeof(string));
                table.Columns.Add("Ver", typeof(string));
                table.Columns.Add("Rechazar", typeof(string));


                foreach (DataRow dr in dt.Rows)
                {

                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }

                GridData.DataSource = table;
                GridData.DataBind();

                for (int i = 0; i < GridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-success' href='TaskDetails.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='DeleteStudent.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a>  ";

                    GridData.Rows[i].Cells[8].Text = up;
                    GridData.Rows[i].Cells[9].Text = del;
                    GridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}