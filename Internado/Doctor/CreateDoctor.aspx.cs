using DaoInternado.Implementation;
using DaoInternado.Model;
using DaoInternado.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Doctor
{
    public partial class CreateDoctor : System.Web.UI.Page
    {
        ValidationDoctor valDoctor = new ValidationDoctor();
        DoctorImpl doctorImpl;
        DaoInternado.Model.Doctor doctor;
        UserImpl userImpl;
        User user;
        int id;
        int insertUser = 1;
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                personAllCombo();
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string password = GeneratePassword(8);

            try
            {
                int selectDoctor = int.Parse(cbxHospital.SelectedValue);
                //string usuario = $"{txtName.Text.Substring(0,1)}{txtLastName.Text}";
                string usuario = txtName.Text;


                doctor = new DaoInternado.Model.Doctor(txtName.Text, txtLastName.Text, txtSecondLastName.Text, int.Parse(txtPhone.Text), txtEmail.Text, txtSpeciality.Text, selectDoctor);
                doctorImpl = new DoctorImpl();
                int insertDoctor = doctorImpl.Insert(doctor);

                user = new User(usuario, password, "Doctor");
                userImpl = new UserImpl();
                int insertUser = userImpl.Insert(user);

                //envio de correo electronico
                valDoctor.Send(usuario, password, txtLastName.Text.Trim(), txtEmail.Text.Trim());

                if (insertDoctor > 0 && insertUser > 0)
                {
                    Response.Redirect("/Doctor/WebDoctor.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void personAllCombo()
        {
            if (!IsPostBack)
            {
                try
                {
                    doctorImpl = new DoctorImpl();
                    DataTable dt = doctorImpl.comboHospital();
                    doctorImpl = new DoctorImpl();
                    cbxHospital.DataSource = dt;
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


        string GeneratePassword( int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomChars);
        }
    }
}