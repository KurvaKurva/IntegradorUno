using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Persistencia;

namespace integradorUno
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Servicios.gestoraTramo.mapper = new tramoMapper();
            Servicios.gestoraOminubs.mapper = new omnibusMapper();
            Servicios.gestoraCiudad.mapper = new ciudadMapper();
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
               new ScriptResourceDefinition
               {
                   Path = "/scripts/jquery-1.12.4.js"
               }
           );
        }
    }
}