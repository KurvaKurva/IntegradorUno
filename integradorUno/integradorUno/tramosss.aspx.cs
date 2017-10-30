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
    public partial class tramosss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarTramos();
            }
        }
        private void cargarTramos()
        {
            lstTramos.DataSource = new gestoraTramo().obtenerTodos();
            lstTramos.DataTextField = "cantKilometros";
            lstTramos.DataValueField = "id";
            lstTramos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Tramo objT = new Tramo()
            {
                cantKilometros = Convert.ToInt32(txtCantKilometros.Text),
                precioBase = Convert.ToInt32(txtPrecioBase.Text),
            };
            var res = new gestoraTramo().agregarTramo(objT);
            if(res.estaCorrecto)
            {
                cargarTramos();
            }
            else
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                var obt = new gestoraTramo().obtenerPorId(Convert.ToInt32(lstTramos.SelectedValue));
                {
                    obt.cantKilometros = Convert.ToInt32(txtModCantKilometros.Text);
                    obt.precioBase = Convert.ToInt32(txtModPrecioBase.Text);
                };                
                var res = new gestoraTramo().modificarTramo(obt);
                if(res.estaCorrecto)
                {
                    cargarTramos();
                }
                else
                {
                    foreach(var err in res.errores)
                    {
                        Page.Validators.Add(new CustomValidator()
                        {
                            ValidationGroup = "Modificar",
                            IsValid = false,
                            ErrorMessage = err,
                        });
                    }
                }
            }
        }

        protected void lstTramos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTramos.SelectedIndex > -1)
            {
                var obt = new gestoraTramo().obtenerPorId(Convert.ToInt32(lstTramos.SelectedValue));

            }
        }
    }
}