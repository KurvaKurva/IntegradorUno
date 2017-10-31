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

        public Resultado modificarOmnibus(Omnibus objO)
        {
            var res = new Resultado();
            if(objO.matricula.Equals(0))
            {
                res.errores.Add("no puede usar esa matricula");
            }
            else
            {
                mapper.modificar(objO);
            }
            return res;
        }
        public List<Omnibus> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
        
        public Omnibus obtenerPorMatricula (string xMatricula)
        {
            return mapper.obtenerPorMatricula(xMatricula);
        }

        public Resultado eliminar (Omnibus objO)
        {
            var res = new Resultado();
            if(objO.matricula == "caca")
            {
                res.errores.Add("No puede ser caca");
            }
            else
            {
                mapper.eliminar(objO);
            }
            return res;
        }
    }
}
