using DaoInternado.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Hospital
{
    public partial class EditHospital : System.Web.UI.Page
    {
        DaoInternado.Model.Hospital hospital;
        HospitalImpl hospitalImpl;
        //public static string sID = "-1";
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
                
                if (type == "U")
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

        void ControllerUpdate()
        {
            hospitalImpl = new HospitalImpl();
            hospital = new DaoInternado.Model.Hospital();
            try
            {
                id = int.Parse(Request.QueryString["id"]);
                if (id > 0)
                {
                    hospital.HospitalID = id;
                    hospital.NameHospital = txtNameHospital.Text;
                    hospital.Latitude = float.Parse(txtLatitude.Text);
                    hospital.Longitude = float.Parse(txtLongitude.Text);
                    hospital.Phone = int.Parse(txtPhone.Text);
                    hospital.Description = txtDescription.Text;
                    hospital.Email = txtEmail.Text;

                    try
                    {
                        
                        int n = hospitalImpl.Update(hospital);

                        if (n > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "success", @"Swal.fire({
                                                                                                  icon: 'error',
                                                                                                  title: 'Los Campos No Deben Contener Errores!',
                                                                                                  showConfirmButton: false,
                                                                                                  timer: 1500
                                                                                                  
                                                                                                })", true);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ControllerUpdate();
        }
    }
}