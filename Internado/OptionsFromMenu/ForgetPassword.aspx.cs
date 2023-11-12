using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Internado
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        User u;
        UserImpl userImpl;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text != "" && txtNewPassword.Text != "" && txtConfirmNewPassword.Text != "")
                {
                    UserImpl existEmail = new UserImpl();
                    userImpl= new UserImpl();
                    DataTable exists = existEmail.Exists(txtEmail.Text);
                    if (exists.Rows.Count > 0)
                    {
                        if (ValidatePassword(txtNewPassword.Text))
                        {
                            if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                            {
                                int a = userImpl.ForgotPassword(txtEmail.Text, txtNewPassword.Text);
                                if (a > 0)
                                {
                                    lblInfo.Text = "Datos de usuario actualizados con exito";
                                    Response.Redirect("Login.aspx");
                                }
                            }
                            else
                            {
                                lblInfo.Text = "Las contraseñas no coinciden";
                            }
                        }
                        else
                        {
                            lblInfo.Text = "La contraseña ingresada no es segura";
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Correo no existente";
                    }
                }
                else
                {
                    lblInfo.Text = "Complete los campos requeridos";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                lblInfo.Text = "La contraseña debe tener al menos 8 caracteres.";
                return false;
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                lblInfo.Text = "La contraseña debe contener al menos una letra mayúscula.";
                return false;
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                lblInfo.Text = "La contraseña debe contener al menos una letra minúscula.";
                return false;
            }

            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
            {
                lblInfo.Text = "La contraseña debe contener al menos un carácter especial.";
                return false;
            }

            return true;
        }

    }
}