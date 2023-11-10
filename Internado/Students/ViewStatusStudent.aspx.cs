using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Students
{
    public partial class ViewStatusStudent : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
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
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.SelectAllStudent();
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
                    string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void selectByStatus(string valorSeleccionado)
        {
            try
            {
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
                    string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        void filterByDate(DateTime start, DateTime end)
        {
            try
            {
                implTask = new TaskStudentImpl();
                DataTable dt = implTask.searchByDate(start, end);
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
                    string imagen = dr["Imagen"] != DBNull.Value ? "data:image;base64," + Convert.ToBase64String((byte[])dr["Imagen"]) : "";
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;
            string valorSeleccionado = ddlDoctor.SelectedItem.Text;

            selectByStatus(valorSeleccionado);

            if (ddlDoctor.SelectedItem.Text == "Filtrar Tareas")
            {
                Select();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LiteralTable.Text = string.Empty;

            string fechaInicioString = TxbStarDate.Text;
            string fechaFinString = TxbEndDate.Text;

            DateTime fechaInicio = DateTime.Parse(fechaInicioString);
            DateTime fechaFin = DateTime.Parse(fechaFinString);

            filterByDate(fechaInicio, fechaFin);

        }
    }
}