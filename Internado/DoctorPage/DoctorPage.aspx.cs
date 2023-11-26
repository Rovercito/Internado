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

namespace Internado.DoctorPage
{
    public partial class DoctorPage : System.Web.UI.Page
    {

        TaskStudentImpl implTask;
        TaskStudent taskSt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;
            selectStatusAll();

            lblUsername.Text = (Session["users"].ToString());

            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Doctor")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }
        
        void selectStatusAll()
        {
            try
            {
                LiteralTable.Text = string.Empty;
                int idUsuario = int.Parse(Session["idPerson"].ToString());
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.GetTask(idUsuario);

                StringBuilder tableHtml = new StringBuilder();
                tableHtml.Append("<table class='table'>");
                tableHtml.Append("<tr>");
                tableHtml.Append("<th>Descripcion</th>");
                tableHtml.Append("<th>Fecha</th>");
                tableHtml.Append("<th>Fecha de Expiracion</th>");
                tableHtml.Append("<th>Imagen</th>");
                tableHtml.Append("<th>Archivo</th>");
                tableHtml.Append("<th>Estado Tarea</th>");
                tableHtml.Append("<th>Estudiante Asignado</th>");
                tableHtml.Append("<th>Opciones</th>");
                tableHtml.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    string descripcion = dr["Descripcion"].ToString();
                    string fecha = dr["Fecha"].ToString();
                    string fechaExpiracion = dr["Fecha de Expiracion"].ToString();
                    string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "/Images/logo.png";
                    string archivo = dr["Archivo"] != DBNull.Value ? "data:application/pdf;base64," + Convert.ToBase64String((byte[])dr["Archivo"]) : "";
                    string estadoTarea = dr["Estado Tarea"].ToString();
                    string estudianteAsignado = dr["Estudiante Asignado"].ToString();
                    string id = dr["idTaskStudent"].ToString();

                    tableHtml.Append("<tr>");
                    tableHtml.Append($"<td>{descripcion}</td>");
                    tableHtml.Append($"<td>{fecha}</td>");
                    tableHtml.Append($"<td>{fechaExpiracion}</td>");
                    tableHtml.Append($"<td><img src='{imagen}' alt='Imagen'  style='max-width:50px; max-height:50px;' /></td>");
                    tableHtml.Append($"<td><a href='{archivo}' download>Descargar PDF</a></td>");
                    tableHtml.Append($"<td>{estadoTarea}</td>");
                    tableHtml.Append($"<td>{estudianteAsignado}</td>");
                    tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='/DoctorPage/TaskUpdate.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i>Modificar</a></td>");
                    tableHtml.Append($"<td><a class='btn btn-sm btn-danger' href='/DoctorPage/TaskDelete.aspx?id={id}&type=D'><i class='fas fa-trash' style='background:#FF0000;'></i>Eliminar</a></td>");
                    tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='/DoctorPage/TaskDetails.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i>Detalles</a></td>");
                   
                    tableHtml.Append("</tr>");
                }

                tableHtml.Append("</table>");

                LiteralTable.Text = tableHtml.ToString();

            }catch(Exception ex)
            {
                throw ex;
            }
        }



        void selectbyStatus()
        {
            try
            {
                LiteralTable.Text = string.Empty;
                string valorSeleccionado = ddlStatus.SelectedItem.Text; ;
                //string valorSeleccionado = "Aceptada";
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.SelectStatus(valorSeleccionado);

                StringBuilder tableHtml = new StringBuilder();
                tableHtml.Append("<table class='table'>");
                tableHtml.Append("<tr>");
                tableHtml.Append("<th>Descripcion</th>");
                tableHtml.Append("<th>Fecha</th>");
                tableHtml.Append("<th>Fecha de Expiracion</th>");
                tableHtml.Append("<th>Imagen</th>");
                tableHtml.Append("<th>Archivo</th>");
                tableHtml.Append("<th>Estado Tarea</th>");
                //tableHtml.Append("<th>Doctor Asignado</th>");
                tableHtml.Append("<th>Estudiante Asignado</th>");
                tableHtml.Append("<th>Ver</th>");
                //tableHtml.Append("<th>Rechazar</th>");
                tableHtml.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    string descripcion = dr["Descripcion"].ToString();
                    string fecha = dr["Fecha"].ToString();
                    string fechaExpiracion = dr["Fecha de Expiracion"].ToString();
                    string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
                    string archivo = dr["Archivo"] != DBNull.Value ? "data:application/pdf;base64," + Convert.ToBase64String((byte[])dr["Archivo"]) : "";
                    string estadoTarea = dr["Estado Tarea"].ToString();
                    //string doctorAsignado = dr["Doctor Asignado"].ToString();
                    string estudianteAsignado = dr["Estudiante Asignado"].ToString();
                    string id = dr["idTaskStudent"].ToString();

                    tableHtml.Append("<tr>");
                    tableHtml.Append($"<td>{descripcion}</td>");
                    tableHtml.Append($"<td>{fecha}</td>");
                    tableHtml.Append($"<td>{fechaExpiracion}</td>");
                    tableHtml.Append($"<td><img src='{imagen}' alt='Imagen'  style='max-width:50px; max-height:50px;' /></td>");
                    tableHtml.Append($"<td><a href='{archivo}' download>Descargar PDF</a></td>");
                    tableHtml.Append($"<td>{estadoTarea}</td>");
                    //tableHtml.Append($"<td>{doctorAsignado}</td>");
                    tableHtml.Append($"<td>{estudianteAsignado}</td>");
                    tableHtml.Append($"<td><a class='btn btn-sm btn-success' href='/DoctorPage/DoctorTaskDetails.aspx?id={id}&type=U'><i class='fas fa-edit' style='color:#000000;'></i></a></td>");
                    //tableHtml.Append($"<td><a class='btn btn-sm btn-danger' href='DeleteStudent.aspx?id={id}&type=D'><i class='fas fa-trash' style='background:#FF0000;'></i>Rechazar</a></td>");
                    tableHtml.Append("</tr>");
                }

                tableHtml.Append("</table>");

                LiteralTable.Text = tableHtml.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            

            selectbyStatus();

            if (ddlStatus.SelectedItem.Text == "Filtrar Tareas")
            {
                selectStatusAll();
            }

        }

        protected void btnAssignTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DoctorPage/DoctorAssingTask.aspx");
        }
    }
}