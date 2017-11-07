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
                cargarPasajes();
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

        private void cargarPasajes()
        {
            lstPasajes.DataSource = new gestoraPasaje().obtenerTodos();
            lstPasajes.DataTextField = "costo";
            lstPasajes.DataValueField = "id";
            lstPasajes.DataBind();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
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
    }
}