using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;

namespace Servicios
{
    public class gestoraCiudad
    {
        public static iCiudad mapper { get; set; }
     /*   public Resultado agregarCiudad(Ciudad objC)
        {
            var resultado = new Resultado();
            if(objC.nombre.Equals(String.Empty))
            {
                resultado.errores.Add("El nombre no puede estar vacío");
            }
            else
            {
                mapper.guardar(objC);
            }
            return resultado;
        }*/

        public List<Ciudad> obtenerTodas()
        {
            return mapper.obtenerTodos();
        }

        public Ciudad obtenerPorId(int xId)
        {
            return mapper.obtenerPorId(xId);
        }
    }
}
