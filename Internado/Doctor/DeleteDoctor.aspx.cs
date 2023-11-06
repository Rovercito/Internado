using DaoInternado.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Doctor
{
    public partial class DeleteDoctor : System.Web.UI.Page
    {
        DoctorImpl doctorImpl;
        DaoInternado.Model.Doctor doctor;
        UserImpl userImpl;
        DaoInternado.Model.User user;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                load();
                hospitalAllCombo();
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

        protected void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    doctorImpl = new DoctorImpl();
                    int n = doctorImpl.Delete(id);
                    Response.Redirect("/Doctor/WebDoctor.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        void load()
        {
            doctorImpl = new DoctorImpl();
            doctor = doctorImpl.Get(id);
            if (doctor != null)
            {
                lblNameValue.Text = doctor.Name.ToString();
                lblLastNameValue.Text = doctor.LastName.ToString();
                lblSecondLastNameValue.Text = doctor.SecondLastName.ToString();
                lblPhoneValue.Text = doctor.Phone.ToString();
                lblEmailValue.Text = doctor.Email.ToString();
                lblSpecialityValue.Text = doctor.Email.ToString();
                cbHospital.SelectedValue = doctor.HospitalID.ToString();
            }
        }

        void hospitalAllCombo()
        {
            if (!IsPostBack)
            {
                try
                {
                    doctorImpl = new DoctorImpl();
                    DataTable dt = doctorImpl.comboHospital();
                    doctorImpl = new DoctorImpl();
                    cbHospital.DataSource = dt;
                    cbHospital.DataTextField = "name";
                    cbHospital.DataValueField = "id";
                    cbHospital.DataBind();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}