using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        User u;
        UserImpl userImpl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["users"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("Logout.aspx");
            }
           
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordController(txtNewPassword.Text);
        }

        void ChangePasswordController(string newPassword)
        {
            try
            {
                if (txtNewPassword.Text != "" && txtConfirmNewPassword.Text != "")
                {
                    u = new User(newPassword);
                    userImpl = new UserImpl();

                    try
                    {
                        int n = userImpl.ChangePassword(u);
                        if (n > 0)
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblInfo.Text = "Error al cambiar la contraseña";
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
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
    }
}