using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginn_Click(object sender, EventArgs e)
        {
            try
            {
                UserImpl implUser = new UserImpl();
                DataTable table = implUser.Login(txtUserName.Text, txtPassword.Text);
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    if (table.Rows.Count > 0)
                    {
                        Session["idPerson"] = int.Parse(table.Rows[0][0].ToString());
                        SessionClass.SessionID = int.Parse(table.Rows[0][0].ToString());
                        Session["users"] = table.Rows[0][1].ToString();
                        Session["role"] = table.Rows[0][3].ToString();

                        switch (table.Rows[0][3].ToString())
                        {
                            case "Administrador":
                                Session["users"] = txtUserName.Text;
                                Session["role"] = "Administrador";
                                Response.Redirect("Default.aspx");
                                break;
                            case "Estudiante":
                                Session["idPerson"] = int.Parse(table.Rows[0][0].ToString());
                                Session["users"] = txtUserName.Text;
                                Session["role"] = "Estudiante";
                                Response.Redirect("StudentPage/StudentPage.aspx");
                                break;
                            case "Doctor":
                                Session["users"] = txtUserName.Text;
                                Session["role"] = "Doctor";
                                Response.Redirect("DoctorPage/DoctorPage.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Nombre de usuario y/o contraseña incorrectos";
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