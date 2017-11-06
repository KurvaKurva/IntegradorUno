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
        public Resultado agegarPasaje(Pasaje objP, Omnibus objO, Horario objH, Ciudad objC)
        {
            var resultado = new Resultado();
            if (objH.dia.Equals(String.Empty))
            {
                resultado.errores.Add("El nombre no puede estar vacío");
            }
            else
            {
                mapper.guardar(objP, objO, objH, objC);
            }
            return resultado;
        }

        public List<Pasaje> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
    }
}
