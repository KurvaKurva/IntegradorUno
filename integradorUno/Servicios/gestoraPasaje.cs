using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using interfacesMapeo;

namespace Servicios
{
    public class gestoraPasaje
    {
        public static iPasaje mapper { get; set; }
        
        public Resultado agegarPasaje(Pasaje objP, Omnibus objO, Horario objH, Ciudad origen, Ciudad destino)
        {
            var resultado = new Resultado();
            if (objP.costo == 0)
            {
                resultado.errores.Add("El nombre no puede estar vacío");
            }
            else
            {
                mapper.guardar(objP, objO, objH, origen, destino);
            }
            return resultado;
        }

        public List<Pasaje> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
    }
}
