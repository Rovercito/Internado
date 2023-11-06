using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
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
                    string up = " <a class='btn btn-sm btn-info' style='width:75px; height:30px;' href='/Hospital/EditHospital.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i> Editar  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' style='width:75px; height:30px;' href='/Hospital/IndexHospital.aspx?id=" + id + "&type=D'> <i class='fas fa-trash' style='background:#FF0000;'> </i> Eliminar </a>  ";

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

        protected void GridDataHospital_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[1].Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btnUpdate = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnUpdate.NamingContainer;
            idHospital = selectedRow.Cells[1].Text;
            Response.Redirect("/Hospital/EditHospital.aspx?id=" + idHospital +"");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            Button btnDelete = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnDelete.NamingContainer;
            idHospital = selectedRow.Cells[1].Text;

            Delete(idHospital);
        }

        private void Delete(string id)
        {
            try
            {
                hospital = new DaoInternado.Model.Hospital();

                hospital.HospitalID = int.Parse(id);
                hospitalImpl = new HospitalImpl();
                int n = hospitalImpl.Delete(hospital);
                if (n > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", @"Swal.fire({
                                                                                                  icon: 'success',
                                                                                                  title: 'Eliminado Con Exito!',
                                                                                                  showConfirmButton: false,
                                                                                                  timer: 1500
                                                                                                  
                                                                                                })", true);
                    LoadDates();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}