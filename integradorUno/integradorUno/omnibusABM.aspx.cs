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
    public partial class omnibusABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarOmnibus();
                cargarCiudad();
            }
        }

       private void cargarOmnibus()
        {
            lstOmnibus.DataSource = new gestoraOminubs().obtenerTodos();            
            lstOmnibus.DataTextField = "matricula";
            lstOmnibus.DataValueField = "id";
            lstOmnibus.DataBind();
        }
      
        private void cargarCiudad()
        {
            var objC = new gestoraCiudad();
            ddlCiudad.DataSource = objC.obtenerTodas();
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "id";
            ddlCiudad.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Omnibus objO = new Omnibus()
            {
                matricula = Convert.ToString(txtMatricula.Text),
                capacidad = Convert.ToInt32(txtCapacidad.Text),
                isLleno = false,
                ciudadActual = new Ciudad() { id = Convert.ToInt32(ddlCiudad.SelectedValue) },
            };
            var res = new gestoraOminubs().agregarOmnibus(objO, objO.ciudadActual);
            {
                if(res.estaCorrecto)
                {
                    cargarOmnibus();                    
                }
                else
                {
                    foreach(var err in res.errores)
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
            if(Page.IsValid)
            {
                /*  var obt = new gestoraOminubs().obtenerPorMatricula(Convert.ToString(lstOmnibus.SelectedValue));
                  {
                      //obt.id = Convert.ToInt32(lstOmnibus.SelectedValue)
                      obt.capacidad = Convert.ToInt32(txtModCapacidad.Text);
                      obt.ciudadActual = new Ciudad() { id = Convert.ToInt32(ddlCiudad.SelectedValue) };
                      //obt.matricula = Convert.ToString(txtModMatricula.Text);
                      obt.isLleno = false;
                  };*/

                var obt = new gestoraOminubs().obtenerPorId(Convert.ToInt32(lstOmnibus.SelectedValue));
                {
                    //obt.id = Convert.ToInt32(lstOmnibus.SelectedValue)
                    obt.capacidad = Convert.ToInt32(txtModCapacidad.Text);
                    obt.ciudadActual = new Ciudad() { id = Convert.ToInt32(ddlCiudad.SelectedValue) };
                    obt.matricula = Convert.ToString(txtModMatricula.Text);
                    obt.isLleno = false;
                };
                var res = new gestoraOminubs().modificarOmnibus(obt);
                {
                    if(res.estaCorrecto)
                    {
                        cargarOmnibus();
                    }
                    else
                    {
                        foreach(var err in res.errores)
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
                var obt = new gestoraOminubs().obtenerPorId(Convert.ToInt32(lstOmnibus.SelectedValue));
                var res = new gestoraOminubs().eliminar(obt);
                if(res.estaCorrecto)
                {
                    cargarOmnibus();
                }
                else
                {
                    foreach(var err in res.errores)
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