using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoInternado.Model;
using DaoInternado.Implementation;
using DaoInternado.Tools;
using DocumentFormat.OpenXml.Bibliography;

namespace Internado.Hospital
{
    public partial class CreateHospital : System.Web.UI.Page
    {
        #region References
        HospitalImpl implHospital;
        DaoInternado.Model.Hospital H;
        ValidationHospital validationHospital;
       
        int id;
        #endregion

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
            CreateController();
        }

        void CreateController()
        {
            validationHospital = new ValidationHospital();
            try
            {
                bool isValidVoid = validationHospital.ValidateVOID(txtNameHospital.Text, txtPhone.Text, txtDescription.Text, txtEmail.Text);
                if (isValidVoid)
                {
                    bool isValidPhone = validationHospital.ValidatePhone(txtPhone.Text);
                    if (isValidPhone)
                    {
                        bool isValidEmail = validationHospital.ValidateEmail(txtEmail.Text);
                        if (isValidEmail)
                        {
                            if (latitudHiddenField.Value != "" && longitudHiddenField.Value != "")
                            {
                                float lat = float.Parse(latitudHiddenField.Value);
                                float lon = float.Parse(longitudHiddenField.Value);


                                H = new DaoInternado.Model.Hospital(txtNameHospital.Text, lat, lon,
                                                  int.Parse(txtPhone.Text), txtDescription.Text, txtEmail.Text);
                                implHospital = new HospitalImpl();
                                int hospital = implHospital.Insert(H);

                                if (hospital > 0)
                                {
                                    Response.Redirect("/Hospital/IndexHospital.aspx");
                                }

                            }
                            else
                            {
                                lblInfo.Visible = true;
                                lblInfo.Text = "Debe poner un marcador de la ubicacion del Hospital en el Mapa";
                            }


                        }
                        else
                        {

                            lblInfo.Text = "Debe de ingresar un Correo Valido!";
                        }
                    }
                    else
                    {

                        lblInfo.Text = "Nose admiten numeros negativos";
                    }

                }
                else
                {
                    lblInfo.Visible = true;
                    lblInfo.Text = "Debe llenar todos los campos";
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}