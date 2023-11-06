using DaoInternado.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DaoInternado.Model;

namespace Internado.StudentPage
{
    public partial class TaskDetails : System.Web.UI.Page
    {
        TaskStudentImpl implTask;
        TaskStudent T;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnFinish.Visible = false;
            btnDelete.Visible = false;
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                LoadType();
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

        void LoadType()
        {
            try
            {
                type = Request.QueryString["type"];

                if (type == "U")
                {
                    Get();
                    btnStart.Visible = true;
                    btnFinish.Visible = true;
                    btnDelete.Visible = false;
                }
                if (type == "D")
                {
                    Get();
                    btnStart.Visible = false;
                    btnFinish.Visible = false;
                    btnDelete.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void Get()
        {
            T = null;
            id = int.Parse(Request.QueryString["id"]);
            try
            {
                if (id > 0)
                {
                    implTask = new TaskStudentImpl();
                    T = implTask.Get(id);
                    if (T != null)
                    {
                        lblDescription.Text = T.Description.ToString();
                        lblDateExpire.Text = T.ExpireDate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implTask = new TaskStudentImpl();
                    int n = implTask.UpdateStart(id);
                    Response.Redirect("StudentPage.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            //Response.Redirect("TaskFinish.aspx");
            id = byte.Parse(Request.QueryString["id"]);

            Response.Redirect("TaskFinish.aspx?id=" + id);
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implTask = new TaskStudentImpl();
                    int n = implTask.DeleteTask(id);
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