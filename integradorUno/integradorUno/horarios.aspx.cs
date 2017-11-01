using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using interfacesMapeo;
using Dominio;

namespace integradorUno
{
    public partial class horarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarHorarios();
            }
        }

        private void cargarHorarios()
        {
            //lstHorarios.DataSource = new gestoraHorarios()
        }
    }
}