using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicios;
using Dominio;

namespace integradorUno
{
    public partial class frmHorarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarHorarios();
                cargarOmnibus();
                cargarTramos();
            }
        }

        private void cargarHorarios()
        {
            lstHorarios.DataSource = new gestoraHorario().obtenerTodos();
            lstHorarios.DataTextField = "datos";
            lstHorarios.DataValueField = "id";
            lstHorarios.DataBind();
        }

        private void cargarOmnibus()
        {
            ddlOmnibus.DataSource = new gestoraOminubs().obtenerTodos();
            ddlOmnibus.DataTextField = "matricula";
            ddlOmnibus.DataValueField = "id";
            ddlOmnibus.DataBind();
        }

        private void cargarTramos()
        {
            ddlTramo.DataSource = new gestoraTramo().obtenerTodos();
            ddlTramo.DataTextField = "cantKilometros";
            ddlTramo.DataValueField = "id";
            ddlTramo.DataBind();
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Horario objH = new Horario()
            {
                horarioSalida = Convert.ToString(txtPartida.Text),
                horarioLlegada = Convert.ToString(txtLlegada.Text),
                dia = Convert.ToString(txtDia.Text),
                objT = new Tramo() { id = Convert.ToInt32(ddlTramo.SelectedValue) },
                objO = new Omnibus() { id = Convert.ToInt32(ddlOmnibus.SelectedValue) },
            };
            var res = new gestoraHorario().agregarHorario(objH, objH.objO, objH.objT);
            {
                if (res.estaCorrecto)
                {
                    cargarHorarios();
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var obt = new gestoraHorario().obtenerPorId(Convert.ToInt32(lstHorarios.SelectedValue));
                {
                    //obt.id = Convert.ToInt32(lstOmnibus.SelectedValue)
                    obt.dia = Convert.ToString(txtModDias.Text);
                    obt.horarioSalida = Convert.ToString(txtModPartida.Text);
                    obt.horarioLlegada = Convert.ToString(txtModLlegada.Text);
                    obt.objO = new Omnibus() { id = Convert.ToInt32(ddlOmnibus.SelectedValue) };
                    obt.objT = new Tramo() { id = Convert.ToInt32(ddlTramo.SelectedValue) };

                };
                var res = new gestoraHorario().modificarHorario(obt);
                {
                    if (res.estaCorrecto)
                    {
                        cargarHorarios();
                    }
                    else
                    {
                        foreach (var err in res.errores)
                        {
                            Page.Validators.Add(new CustomValidator()
                            {
                                ValidationGroup = "modificar",
                                IsValid = false,
                                ErrorMessage = err,
                            });
                        }
                    }
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //var obt = new gestoraOminubs().obtenerPorMatricula(Convert.ToString(lstOmnibus.SelectedValue));
                var obt = new gestoraHorario().obtenerPorId(Convert.ToInt32(lstHorarios.SelectedValue));
                var res = new gestoraHorario().eliminar(obt);
                if (res.estaCorrecto)
                {
                    cargarHorarios();
                }
                else
                {
                    foreach (var err in res.errores)
                    {
                        Page.Validators.Add(new CustomValidator()
                        {
                            ValidationGroup = "Eliminar",
                            IsValid = false,
                            ErrorMessage = err,
                        });
                    }
                }
            }
        }
    }
}
