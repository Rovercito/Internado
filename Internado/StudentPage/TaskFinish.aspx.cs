using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.StudentPage
{
    public partial class TaskFinish : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                //Get();
            }
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Estudiante")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaskDetails.aspx");
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implTask = new TaskStudentImpl();
                    int n = implTask.UpdateTask(id,fileImage.FileBytes,fileAttachment.FileBytes);
                    Response.Redirect("StudentPage.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}