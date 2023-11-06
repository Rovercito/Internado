﻿using DaoInternado.Implementation;
using DaoInternado.Model;
using System;
using System.Collections.Generic;
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
                lblLastName.Text = S.LastName.ToString();
                lblSecondLastName.Text = S.SecondLastName.ToString();
                lblPhone.Text = S.Phone.ToString();
                lblEmail.Text = S.Email.ToString();
                lblSpeciality.Text = S.Email.ToString();
                ddlDoctor.SelectedValue = S.DoctorID.ToString();
                ddlHospital.SelectedValue = S.HospitalID.ToString();
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
    }
}