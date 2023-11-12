using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internado.Hospital
{
    public partial class IndexHospital : System.Web.UI.Page
    {
        HospitalImpl hospitalImpl;
        DaoInternado.Model.Hospital hospital;
        string idHospital;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadDates();
            ShowDates();
            if (Session["users"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

         void ShowDates()
         {
             try
             {
                 hospitalImpl = new HospitalImpl();
                 DataTable dt = hospitalImpl.Select();
                 DataTable table = new DataTable("Hospital");
                 table.Columns.Add("Nombre del Hospital", typeof(string));
                 table.Columns.Add("Latitud", typeof(string));
                 table.Columns.Add("Longitud", typeof(string));
                 table.Columns.Add("Telefono", typeof(string));
                 table.Columns.Add("Descripcion", typeof(string));
                 table.Columns.Add("Correo Electronico", typeof(string));
                 table.Columns.Add("Editar", typeof(string));
                 table.Columns.Add("Eliminar", typeof(string));


                 foreach (DataRow dr in dt.Rows)
                 {
                     table.Rows.Add(dr[1].ToString(), 
                                    dr[2].ToString(), 
                                    dr[3].ToString(), 
                                    dr[4].ToString(), 
                                    dr[5].ToString(), 
                                    dr[6].ToString());
                 }

                 GridDataHospital.DataSource = table;
                 GridDataHospital.DataBind();

                 for (int i = 0; i < GridDataHospital.Rows.Count; i++)
                 {
                     string id = dt.Rows[i][0].ToString();
                     string editTooltip = "Editar Hospital " + GridDataHospital.Rows[i].Cells[0].Text;
                     string deleteTooltip = "Eliminar Hospital " + id;




                     string up = $@" <a class='btn btn-sm btn-warning' style='width:75px; height:30px;' href='/Hospital/EditHospital.aspx?id={id}&type=U' data-bs-toggle='tooltip' data-bs-placement='top' title='{editTooltip}' > <i class='fas fa-edit' style='color:#000000;'> </i></a> ";
                     string del = $@" <a class='btn btn-sm btn-danger' style='width:75px; height:30px;' href='/Hospital/DeleteHospital.aspx?id={id}&type=D' data-bs-toggle='tooltip' data-bs-placement='top' title='{deleteTooltip}'> <i class='fas fa-trash' style='background:#FF0000;'> </i></a>  ";

                     GridDataHospital.Rows[i].Cells[6].Text = up;
                     GridDataHospital.Rows[i].Cells[7].Text = del;
                     GridDataHospital.Rows[i].Attributes["data-id"] = id;

                 }

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

    


        void LoadDates()
        {
            try
            {
                hospitalImpl = new HospitalImpl();
                GridDataHospital.DataSource = hospitalImpl.Select();
                GridDataHospital.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

      
        protected void btnCrearHospital_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Hospital/CreateHospital.aspx");
        }

        protected void BtnReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Hospital/ReportHospital.aspx");
        }
    }
}