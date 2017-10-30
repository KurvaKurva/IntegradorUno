using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;

namespace Servicios
{
    public class gestoraOminubs
    {
        public static iOmnibus mapper { get; set; }

        public Resultado agregarOmnibus(Omnibus objO, Ciudad objC)
        {
            var Resultado = new Resultado();
            if(objO.matricula.Equals(0))
            {
                Resultado.errores.Add("No puede usar esa matrícula");
            }
            else
            {
                mapper.guardar(objO, objC);
            }
            return Resultado;
        }

        public List<Omnibus> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
    }
}
