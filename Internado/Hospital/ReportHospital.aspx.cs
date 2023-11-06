using DaoInternado.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Internado.Hospital
{
    public partial class ReportHospital : System.Web.UI.Page
    {
        HospitalImpl hospitalIMPL;
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
            ShowReport();
            ShowHospital();
        }

        private void ShowHospital()
        {
            hospitalIMPL = new HospitalImpl();
            try
            {
                ddlFilterHospital.DataSource = hospitalIMPL.LoadComboBoxHospital();
               
                ddlFilterHospital.DataTextField = "name";
                ddlFilterHospital.DataValueField = "idHospital";

               
                
                ddlFilterHospital.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ShowReport()
        {
            try
            {
                try
                {
                    hospitalIMPL = new HospitalImpl();
                    DataTable dt = hospitalIMPL.SelectReport();
                    DataTable table = new DataTable("ReportHospital");
                    table.Columns.Add("Hospital", typeof(string));
                    table.Columns.Add("Direccion", typeof(string));
                    table.Columns.Add("Telefono", typeof(string));
                    table.Columns.Add("Correo Electronico", typeof(string));
                    table.Columns.Add("Doctor Cabezera", typeof(string));
                    table.Columns.Add("Total Estudiantes", typeof(int));

                    foreach (DataRow dr in dt.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    gvReportHospital.DataSource = table;
                    gvReportHospital.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetShowReport(int id)
        {
            try
            {
                try
                {
                    hospitalIMPL = new HospitalImpl();
                    DataTable dt = hospitalIMPL.GetReportHospital(id);
                    DataTable table = new DataTable("ReportHospital");
                    table.Columns.Add("Hospital", typeof(string));
                    table.Columns.Add("Direccion", typeof(string));
                    table.Columns.Add("Telefono", typeof(string));
                    table.Columns.Add("Correo Electronico", typeof(string));
                    table.Columns.Add("Doctor Cabezera", typeof(string));
                    table.Columns.Add("Total Estudiantes", typeof(int));

                    foreach (DataRow dr in dt.Rows)
                    {
                        table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    gvReportHospital.DataSource = table;
                    gvReportHospital.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlFilterHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            id = int.Parse(ddlFilterHospital.SelectedValue);
            GetShowReport(id);
        }
    }
}