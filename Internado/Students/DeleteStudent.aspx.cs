﻿using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Internado.Students
{
    public partial class DeleteStudent : System.Web.UI.Page
    {
        StudentImpl implStudent;
        Student S;
        UserImpl implUser;
        User U;
        string type;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"]);
                load();
                fillCombo1();
                fillCombo2();
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


        void load()
        {
            implStudent = new StudentImpl();
            S = implStudent.Get(id);
            if (S != null)
            {
                lblNameValue.Text= S.Name.ToString();
                lblLastNameValue .Text = S.LastName.ToString();
                lblSecondLastNameValue.Text = S.SecondLastName.ToString();
                lblPhoneValue.Text = S.Phone.ToString();
                lblEmailValue.Text = S.Email.ToString();
                lblSpecialityValue.Text = S.Speciality.ToString();
                ddlDoctor.SelectedValue = S.DoctorID.ToString();
                ddlHospital.SelectedValue = S.HospitalID.ToString();

                //string nombreDoctor = ObtenerNombreDoctorId(S.DoctorID);
            }
        }

        void fillCombo1()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBox();
                    implStudent = new StudentImpl();
                    ddlDoctor.DataSource = combo;
                    ddlDoctor.DataTextField = "name";
                    ddlDoctor.DataValueField = "id";
                    //Brand.DataSource = combo.DefaultView;
                    ddlDoctor.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        void fillCombo2()
        {
            if (!IsPostBack)
            {
                try
                {
                    implStudent = new StudentImpl();
                    DataTable combo = implStudent.ComboBox2();
                    implStudent = new StudentImpl();
                    ddlHospital.DataSource = combo;
                    ddlHospital.DataTextField = "name";
                    ddlHospital.DataValueField = "id";
                    ddlHospital.DataBind();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implStudent = new StudentImpl();
                    int n = implStudent.Delete(id);
                    Response.Redirect("WebStudent.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        //private string ObtenerNombreDoctorId(int id)
        //{

        //}
    }
}