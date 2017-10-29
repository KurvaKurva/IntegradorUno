using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;

namespace Servicios
{
    public class gestoraTramo
    {
        public static iTramo mapper { get; set; }

        public List<Tramo> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
    }

}
