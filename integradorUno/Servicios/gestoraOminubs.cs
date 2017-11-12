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
            if(objO.matricula == "")
            {
                Resultado.errores.Add("No puede usar esa matrícula");
            }
            else if(objO.capacidad > 46)
            {
                Resultado.errores.Add("El número ingresado supera la capacidad del ómnibus");
            }
            
            else
            {
                mapper.guardar(objO, objC);
            }
            return Resultado;
        }

        public bool verificarMatricula(int xId, string xMatricula)
        {
            var obt = obtenerPorId(xId);
            if(obt.matricula == xMatricula)
            {
                return false;
            }
            return true;
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

        public Omnibus obtenerPorId(int xId)
        {
            return mapper.obtenerPorId(xId);
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
