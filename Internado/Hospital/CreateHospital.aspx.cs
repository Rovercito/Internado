using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Model;
using DaoInternado.Implementation;

namespace Internado.Hospital
{
    public partial class CreateHospital : System.Web.UI.Page
    {
        HospitalImpl implHospital;
        DaoInternado.Model.Hospital H;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            txtLatitude.ReadOnly = true;
            txtLongitude.ReadOnly = true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                float lat = float.Parse(latitudHiddenField.Value);
                float lon = float.Parse(longitudHiddenField.Value);

                H = new DaoInternado.Model.Hospital(txtNameHospital.Text, lat, lon,
                                                    int.Parse(txtPhone.Text), txtDescription.Text, txtEmail.Text);
                implHospital = new HospitalImpl();
                int hospital = implHospital.Insert(H);

                if ( hospital > 0)
                {
                    Response.Redirect("/Hospital/IndexHospital.aspx");
                }
            }
            
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}