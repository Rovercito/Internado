using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Model;
using DaoInternado.Implementation;

namespace Internado.DoctorPage
{
    public partial class TaskUpdate : System.Web.UI.Page
    {
        TaskStudent task;
        TaskStudentImpl taskImpl;
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

                if (type == "U")
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
                    task = taskImpl.GetTaskStudent(id);

                    DateTime datebdd = task.ExpireDate;

                    txtDescription.Text = task.Description.ToString();
                    txtAssingDateExpired.Text = datebdd.ToString("yyyy-MM-dd");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        void ControllerUpdate()
        {
            task = new TaskStudent();
            taskImpl = new TaskStudentImpl();

            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    task.Id = id;
                    task.Description = txtDescription.Text;
                    task.ExpireDate = DateTime.Parse(txtAssingDateExpired.Text);


                    try
                    {

                        int n = taskImpl.Update(task);

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ControllerUpdate();
        }
    }
}