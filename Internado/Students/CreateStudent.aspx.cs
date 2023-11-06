using DaoInternado.Implementation;
using DaoInternado.Model;
using DaoInternado.Tools;
using System;
using System.Data;

namespace Internado.Students
{
    public partial class CreateStudent : System.Web.UI.Page
    {
        ValidationStudent vl = new ValidationStudent();
        StudentImpl implStudent;
        Student S;
        UserImpl implUser;
        User U;
        int id;
        Random random = new Random();

        bool b1 = false, b2 = false, b3 = false, b4 = false, b5 = false, b6 = false, b7 = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillCombo2();
                fillCombo1();
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
            ValidName(txtName.Text);
            ValidLastName(txtLastName.Text);
            ValidSecondLastName(txtSecondLastName.Text);
            ValidPhone(txtPhone.Text);
            ValidEmail(txtEmail.Text);
            string password = GeneratePassword(8);


            if (b1 == true && b2 == true && b3 == true && b5 == true && b6 == true && int.Parse(ddlDoctor.SelectedValue) > 0 && int.Parse(ddlHospital.SelectedValue) > 0)
            {
                /*try
                {*/
                int selectedDoctor = int.Parse(ddlDoctor.SelectedValue);
                int selectedHospital = int.Parse(ddlHospital.SelectedValue);
                string usern = $"{txtName.Text.Substring(0, 1)}{txtLastName.Text}";

                S = new Student(txtName.Text, txtLastName.Text, txtSecondLastName.Text, int.Parse(txtPhone.Text), txtEmail.Text, txtSpeciality.Text, selectedDoctor, selectedHospital);
                implStudent = new StudentImpl();
                int n = implStudent.Insert(S);


                U = new User(usern, password, "Estudiante");
                implUser = new UserImpl();
                int m = implUser.Insert(U);

                vl.Send(usern, password, txtEmail.Text);

                if (n > 0 && m > 0)
                {
                    Response.Redirect("/Students/WebStudent.aspx");
                }
                /*}
                catch (Exception ex)
                {
                    string mensajeError = "Error al enviar el correo: " + ex.ToString();

                    lblError.Text = mensajeError;
                    throw ex;
                }*/
            }
            else
            {

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




        #region Validations
        void ValidName(string name)
        {
            if (name == "")
            {
                lblControl1.Text = "El campo no puede estar vacío.";
                b1 = false;
            }
            else if (!vl.IsOnlyLetters(name))
            {
                lblControl1.Text = "El formato de entrada no es válido.";
                b1 = false;
            }
            else
            {
                lblControl1.Text = "";
                b1 = true;
            }
        }
        void ValidLastName(string LastName)
        {
            if (LastName == "")
            {
                lblControl2.Text = "El campo no puede estar vacío.";
                b2 = false;

            }
            else if (!vl.IsOnlyLetters(LastName))
            {
                lblControl2.Text = "El formato de entrada no es válido.";
                b2 = false;

            }
            else
            {
                lblControl2.Text = "";
                b2 = true;
            }
        }
        void ValidSecondLastName(string SecondLastName)
        {
            if (SecondLastName != "")
            {
                if (!vl.IsOnlyLetters(SecondLastName))
                {
                    lblControl3.Text = "El formato de entrada no es válido.";
                    b3 = false;

                }
                else
                {
                    lblControl3.Text = "";
                    b3 = true;
                }
            }
            else
            {
                lblControl3.Text = "";
                b3 = true;
            }
        }
        void ValidAddress(string Address)
        {
            if (Address == "")
            {
                lblControl4.Text = "El campo no puede estar vacío.";
                b4 = false;

            }
            else if (!vl.VlAdress(Address))
            {
                lblControl4.Text = "El formato de entrada no es válido.";
                b4 = false;

            }
            else
            {
                lblControl4.Text = "";
                b4 = true;
            }
        }
        void ValidPhone(string Phone)
        {
            if (Phone == "")
            {
                lblControl5.Text = "El campo no puede estar vacío.";
                b5 = false;

            }
            else if (!vl.IsOnlyNumbers(Phone))
            {
                lblControl5.Text = "El formato de entrada no es válido.";
                b5 = false;

            }
            else if (Phone.Length > 10 || Phone.Length < 8)
            {
                lblControl5.Text = "La longitud no es válida.";
                b5 = false;
            }
            else
            {
                lblControl5.Text = "";
                b5 = true;
            }
        }
        void ValidEmail(string Email)
        {
            if (Email == "")
            {
                lblControl6.Text = "El campo no puede estar vacío.";
                b6 = false;
            }
            else if (!vl.ValidateEmail(Email))
            {
                lblControl6.Text = "El formato de entrada no es válido.";
                b6 = false;
            }
            else
            {
                lblControl6.Text = "";
                b6 = true;
            }
        }
        #endregion



        string GeneratePassword(int length)
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