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


    }
}