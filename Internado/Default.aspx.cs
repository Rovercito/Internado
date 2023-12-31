﻿using DaoInternado.Implementation;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Internado
{
    public partial class Default : System.Web.UI.Page
    {
        GraphicsImpl graphicsImpl;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CargarDatosGrafico();

            if(!IsPostBack)
            {
                CargarDatosGrafico();
            }


            if (Session["users"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["users"] != null && Session["role"].ToString() != "Administrador")
            {
                Response.Redirect("Logout.aspx");
            }
            else
            {
                //Response.Redirect("WebLogin.aspx");
            }
        }

        public string CargarDatosPorEstados()
        {
            graphicsImpl = new GraphicsImpl();

            int asignados = graphicsImpl.ObtenerTareasPendiente();
            int aceptados = graphicsImpl.ObtenerTareasAceptada();
            int terminado = graphicsImpl.ObtenerTareasTerminada();
            int rechazado = graphicsImpl.ObtenerTareasRechazada();

            var data = new
            {
                labels = new[] { "Asignados", "Aceptados", "Terminados", "Rechazados" },
                datasets = new[]
                    {
                        new
                        {
                            data = new[] { asignados, aceptados, terminado, rechazado },
                            backgroundColor = new[] { "rgba(255, 206, 86, 0.5)", "rgba(75, 192, 192, 0.5)", "rgba(54, 162, 235, 0.5)", "rgba(255, 99, 132, 0.5)" },
                            borderColor = new[] { "rgba(255, 206, 86, 1)", "rgba(54, 162, 235, 1)", "rgba(75, 192, 192, 1)", "rgba(255, 99, 132, 1)" },
                            borderWidth = 1
                        }
                }
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public string CargarDatosGrafico()
        {
            graphicsImpl = new GraphicsImpl();

            int cantidadDoctores = graphicsImpl.ObtenerCantidadDoctores();
            int cantidadInternos = graphicsImpl.ObtenerCantidadEstudiantes();
            int cantidadHospital = graphicsImpl.ObtenerCantidadHospital();

            var data = new
            {
                labels = new[] { "Internos", "Doctores", "Hospitales" },
                datasets = new[]
                {
                new
                {
                    data = new[] { cantidadInternos, cantidadDoctores, cantidadHospital },
                    backgroundColor = new[] { "rgba(255, 99, 132, 0.5)", "rgba(54, 162, 235, 0.5)", "rgba(255, 206, 86, 0.5)" },
                    borderColor = new[] { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)" },
                    borderWidth = 1
                }
            }
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }


        public string CargarDatosHospital()
        {
            graphicsImpl = new GraphicsImpl();

            int cantidadDoctores = graphicsImpl.ObtenerCantidadDoctores();
            int cantidadInternos = graphicsImpl.ObtenerCantidadEstudiantes();

            var data = new
            {
                labels = new[] { "Internos", "Doctores" },
                datasets = new[]
                {
                new
                {
                    data = new[] { cantidadInternos, cantidadDoctores },
                    backgroundColor = new[] { "rgba(255, 99, 132, 0.5)", "rgba(54, 162, 235, 0.5)", "rgba(255, 206, 86, 0.5)" },
                    borderColor = new[] { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)" },
                    borderWidth = 1
                }
            }
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

    }
}