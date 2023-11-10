using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Implementation;
using DaoInternado.Model;

namespace Internado.DoctorPage
{
    public partial class DoctorAssingTask : System.Web.UI.Page
    {
        TaskStudentImpl taskStudentImpl;
        TaskStudent taskStudent;

        StudentImpl implStudent;
        Student S;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillComboStudent();
            }

            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            TaskController();
        }

        void TaskController()
        {
            try
            {
                int selectStudent = int.Parse(cmbStudent.SelectedValue);
                string statusTask = "Pendiente";


                taskStudent = new TaskStudent(txtDescription.Text, DateTime.Parse(txtAssingDate.Text), DateTime.Parse(txtAssingDateExpired.Text), statusTask, SessionClass.SessionID, selectStudent);
                taskStudentImpl = new TaskStudentImpl();

                int n = taskStudentImpl.Insert(taskStudent);
                
                
                //taskStudentImpl.Send(selectStudent, txtAssingDate.Text, txtAssingDateExpired.Text);
                


                if (n > 0)
                {
                    Response.Redirect("/DoctorPage/DoctorPage.aspx");
                }
                else
                {
                    Response.Redirect("/Doctor/WebDoctor.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void FillComboStudent()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBoxStudent();
                    implStudent = new StudentImpl();
                    cmbStudent.DataSource = combo;
                    cmbStudent.DataTextField = "name";
                    cmbStudent.DataValueField = "id";
                    cmbStudent.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}