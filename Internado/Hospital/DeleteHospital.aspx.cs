using DaoInternado.Implementation;
using DaoInternado.Model;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Hospital
{
    public partial class DeleteHospital : System.Web.UI.Page
    {
        HospitalImpl hospitalImpl;
        DaoInternado.Model.Hospital hospital;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                ControllerType(id);
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

        void ControllerType(int id)
        {
            try
            {
                type = Request.QueryString["type"];

                if (type == "D")
                {
                    ControllerID(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void ControllerID(int id)
        {
            hospital = new DaoInternado.Model.Hospital();
            hospitalImpl = new HospitalImpl();

            if (id > 0)
            {
                try
                {
                    hospital = hospitalImpl.GetHospital(id);

                    txtNameHospital.Text = hospital.NameHospital;
                    txtLatitude.Text = hospital.Latitude.ToString();
                    txtLongitude.Text = hospital.Longitude.ToString();
                    txtPhone.Text = hospital.Phone.ToString();
                    txtDescription.Text = hospital.Description;
                    txtEmail.Text = hospital.Email;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteController();
        }

        void DeleteController()
        {
            hospitalImpl = new HospitalImpl();
            hospital = new DaoInternado.Model.Hospital();
            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    hospital.HospitalID = id;
                    try
                    {

                        int n = hospitalImpl.Delete(hospital);

                        if (n > 0)
                        {
                            Response.Redirect("/Hospital/IndexHospital.aspx");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
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