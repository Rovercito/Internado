using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Doctor
{
    public partial class EditDoctor : System.Web.UI.Page
    {
        DoctorImpl doctorImpl;
        DaoInternado.Model.Doctor doctor;
        UserImpl userImpl;
        User user;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //id = int.Parse(Request.QueryString["id"]);
                loadType();
                allHospital();
            }
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("~/Logout.aspx");
            }
            else
            {
                //Response.Redirect("WebLogin.aspx");
            }
        }

        protected void btnEditarDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                //int selectedDoctor = int.Parse(ddlDoctor.SelectedValue);
                int selectedHospital = int.Parse(cbxHospital.SelectedValue);

                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    doctorImpl = new DoctorImpl();
                    DaoInternado.Model.Doctor doc = new DaoInternado.Model.Doctor(txtName.Text, txtLastName.Text, txtSecondLastName.Text, int.Parse(txtPhone.Text), txtEmail.Text, txtSpeciality.Text, selectedHospital);
                    doctorImpl.Update2(doc, id);
                    Response.Redirect("WebDoctor.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void loadType()
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

        void allHospital()
        {
            if (!IsPostBack)
            {
                try
                {
                    doctorImpl = new DoctorImpl();
                    DataTable combo = doctorImpl.comboHospital();
                    doctorImpl = new DoctorImpl();
                    cbxHospital.DataSource = combo;
                    cbxHospital.DataTextField = "name";
                    cbxHospital.DataValueField = "id";
                    cbxHospital.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        void Get()
        {
            doctor = null;
            id = int.Parse(Request.QueryString["id"]);
            try
            {
                if (id > 0)
                {
                    doctorImpl = new DoctorImpl();
                    doctor = doctorImpl.Get(id);
                    if (doctor != null)
                    {
                        txtName.Text = doctor.Name.ToString();
                        txtLastName.Text = doctor.LastName.ToString();
                        txtSecondLastName.Text = doctor.SecondLastName.ToString();
                        txtPhone.Text = doctor.Phone.ToString();
                        txtEmail.Text = doctor.Email.ToString();
                        txtSpeciality.Text = doctor.Speciality.ToString();
                        cbxHospital.SelectedValue = doctor.HospitalID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}