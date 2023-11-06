using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Implementation;
using DaoInternado.Model;

namespace Internado.DoctorPage
{
    public partial class TaskDelete : System.Web.UI.Page
    {
        TaskStudentImpl taskImpl;
        TaskStudent task;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                ControllerType(id);
            }
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Doctor")
            {
                Response.Redirect("~/Logout.aspx");
            }
            else
            {
                //Response.Redirect("WebLogin.aspx");
            }
        }

        void ControllerType(int id)
        {
            try
            {
                type = Request.QueryString["type"];

                if (type == "D")
                {
                    ControllerID(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void ControllerID(int id)
        {
            task = new TaskStudent();
            taskImpl = new TaskStudentImpl();

            if (id > 0)
            {
                try
                {
                    task = taskImpl.GetTaskStudentDelete(id);

                    DateTime startDate = task.ExpireDate;
                    DateTime endDate = task.ExpireDate;

                    lblDescripcionValue.Text = task.Description.ToString();
                    txtAssingDate.Text = endDate.ToString("yyyy-MM-dd");
                    txtAssingDateExpired.Text = startDate.ToString("yyyy-MM-dd");
                    cmbStudent.SelectedValue = task.IdStudent.ToString();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        void ControllerDelete()
        {
            task = new TaskStudent();
            taskImpl = new TaskStudentImpl();

            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    try
                    {
                        task.Id = id;


                        int n = taskImpl.Delete(task);

                        if (n > 0)
                        {

                            Response.Redirect("/DoctorPage/DoctorPage.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            ControllerDelete();
        }
    }
}