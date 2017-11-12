using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using interfacesMapeo;
using Servicios;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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
                cargarPasajes();
                cargarTramos();
                cargarTramosAAgregar();                
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

        private void cargarTramos()
        {
            lstTramos.DataSource = new gestoraTramo().obtenerTodos();
            lstTramos.DataTextField = "cantKilometros";
            lstTramos.DataValueField = "id";
            lstTramos.DataBind();
        }
        private void cargarPasajesEntreRangos()
        {
            lstPasajesEntreRangos.DataSource = new gestoraPasaje().obtenerPasajesEntreFechas(Convert.ToInt32(lstTramos.SelectedValue), clndInicio.SelectedDate, clndFin.SelectedDate);
            lstPasajesEntreRangos.DataTextField = "costo";
            lstPasajesEntreRangos.DataValueField = "id";
            lstPasajesEntreRangos.DataBind();
        }

        private void cargarTramosAAgregar()
        {
            ddlTramosAAgregar.DataSource = new gestoraTramo().obtenerTodos();
            ddlTramosAAgregar.DataTextField = "datos";
            ddlTramosAAgregar.DataValueField = "id";
            ddlTramosAAgregar.DataBind();
        }

        private void cargarPasajes()
        {
            lstPasajes.DataSource = new gestoraPasaje().obtenerTodos();
            lstPasajes.DataTextField = "datos";
            lstPasajes.DataValueField = "id";
            lstPasajes.DataBind();
        }
        private void cargarTramosDelPasaje()
        {
            lstTramosDelPasaje.DataSource = new gestoraLinea().obtenerTodos();
            lstTramosDelPasaje.DataTextField = "datos";
            lstTramosDelPasaje.DataValueField = "id";
            lstTramosDelPasaje.DataBind();
        }
        protected void btnAgregarTramo_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Linea objL = new Linea()
                {
                    objT = new Tramo() { id = Convert.ToInt32(ddlTramosAAgregar.SelectedValue) },
                };
                var res = new gestoraLinea().agregarLinea(objL.objT);
                {
                    if(res.estaCorrecto)
                    {
                        cargarTramosDelPasaje();
                    }
                }
            }
        }
       /* protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Pasaje objP = new Pasaje()
                {
                    costo = Convert.ToInt32(txtCosto.Text),
                    fecha = Convert.ToDateTime(clndFecha.SelectedDate),
                    origen = new Ciudad() { id = Convert.ToInt32(ddlCiudadOrigen.SelectedValue) },
                    destino = new Ciudad() { id = Convert.ToInt32(ddlCiudadDestino.SelectedValue) },
                    objO = new Omnibus() { id = Convert.ToInt32(ddlOmnibus.SelectedValue) },
                    objH = new Horario() { id = Convert.ToInt32(ddlHorario.SelectedValue) },
                };
            var res = new gestoraPasaje().agegarPasaje(objP, objP.objO, objP.objH, objP.origen, objP.destino);
            {
                if (res.estaCorrecto)
                {
                    cargarOmnibus();
                    cargarPasajes();

                }
                else
                {
                    foreach (var err in res.errores)
                    {
                        Page.Validators.Add(new CustomValidator()
                        {
                            ValidationGroup = "Alta",
                            IsValid = false,
                            ErrorMessage = err,
                        });
                    }
                }
            }
            }
        }*/

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            lstPasajesEntreRangos.DataSource = new gestoraPasaje().obtenerPasajesEntreFechas(Convert.ToInt32(lstTramos.SelectedValue), clndInicio.SelectedDate, clndFin.SelectedDate);
            cargarPasajesEntreRangos();
            var asd = new gestoraPasaje().obtenerCostoTotalDePasajesSegunTramoYFechas(Convert.ToInt32(lstTramos.SelectedValue), clndInicio.SelectedDate, clndFin.SelectedDate);            
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            pnlTotalFacturado.Visible = true;
            pnlPasajes.Visible = false;
        }

        protected void btnNuevoPasaje_Click(object sender, EventArgs e)
        {
            pnlTotalFacturado.Visible = false;
            pnlPasajes.Visible = true;
        }

      
    }
}