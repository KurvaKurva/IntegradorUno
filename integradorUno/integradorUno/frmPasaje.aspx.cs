using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using interfacesMapeo;
using Servicios;

namespace integradorUno
{
    public partial class frmPasaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarOmnibus();
                cargarCiudadDestino();
                cargarCiudadOrigen();
                cargarHorarios();                
            }
        }
        private void cargarOmnibus()
        {
            ddlOmnibus.DataSource = new gestoraOminubs().obtenerTodos();
            ddlOmnibus.DataTextField = "matricula";
            ddlOmnibus.DataValueField = "id";
            ddlOmnibus.DataBind();
        }
        private void cargarCiudadDestino()
        {
            ddlCiudadDestino.DataSource = new gestoraCiudad().obtenerTodas();
            ddlCiudadDestino.DataTextField = "nombre";
            ddlCiudadDestino.DataValueField = "id";
            ddlCiudadDestino.DataBind();
        }
        private void cargarCiudadOrigen()
        {
            ddlCiudadOrigen.DataSource = new gestoraCiudad().obtenerTodas();
            ddlCiudadOrigen.DataTextField = "nombre";
            ddlCiudadOrigen.DataValueField = "id";
            ddlCiudadOrigen.DataBind();
        }

        private void cargarHorarios()
        {
            ddlHorario.DataSource = new gestoraHorario().obtenerTodos();
            ddlHorario.DataTextField = "datos";
            ddlHorario.DataValueField = "id";
            ddlHorario.DataBind();
        }

 
    }
}