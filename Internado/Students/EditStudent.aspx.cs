using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Students
{
    public partial class EditStudent : System.Web.UI.Page
    {
        StudentImpl implStudent;
        Student S;
        UserImpl implUser;
        User U;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                LoadType();
                fillCombo1();
                fillCombo2();
            }
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void Get()
        {
            S = null;
            id = int.Parse(Request.QueryString["id"]);
            try
            {
                if (id > 0)
                {
                    implStudent = new StudentImpl();
                    S = implStudent.Get(id);
                    if (S != null)
                    {
                        txtName.Text = S.Name.ToString();
                        txtLastName.Text = S.LastName.ToString();
                        txtSecondLastName.Text = S.SecondLastName.ToString();
                        txtPhone.Text = S.Phone.ToString();
                        txtEmail.Text = S.Email.ToString();
                        txtSpeciality.Text = S.Speciality.ToString();   //S.Email.ToString();
                        ddlDoctor.SelectedValue = S.DoctorID.ToString();
                        ddlHospital.SelectedValue = S.HospitalID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedDoctor = int.Parse(ddlDoctor.SelectedValue);
                int selectedHospital = int.Parse(ddlHospital.SelectedValue);

                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    implStudent = new StudentImpl();
                    Student s = new Student(txtName.Text, txtLastName.Text, txtSecondLastName.Text, int.Parse(txtPhone.Text),txtEmail.Text,txtSpeciality.Text, selectedDoctor,selectedHospital);
                    implStudent.Update2(s,id);
                    Response.Redirect("WebStudent.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void fillCombo1()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBox();
                    implStudent = new StudentImpl();
                    ddlDoctor.DataSource = combo;
                    ddlDoctor.DataTextField = "name";
                    ddlDoctor.DataValueField = "id";
                    //Brand.DataSource = combo.DefaultView;
                    ddlDoctor.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        void fillCombo2()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBox2();
                    implStudent = new StudentImpl();
                    ddlHospital.DataSource = combo;
                    ddlHospital.DataTextField = "name";
                    ddlHospital.DataValueField = "id";
                    ddlHospital.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}