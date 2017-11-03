using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;
namespace Servicios
{
    public class gestoraHorario
    {
        public static iHorario mapper { get; set; }
       public Resultado agregarHorario(Horario objH, Omnibus objO, Tramo objT)
        {
          var resultado = new Resultado();
          if(objH.dia.Equals(String.Empty))
          {
              resultado.errores.Add("El nombre no puede estar vacío");
          }
          else
          {
              mapper.guardar(objH,objO,objT);
          }
          return resultado;
        }

        public Resultado modificarHorario(Horario objH)
        {
            var res = new Resultado();
            if (objH.dia.Equals(String.Empty))
            {
                res.errores.Add("El tramo no tiene una cantidad de kilómetros asignada.");
            }
            else
            {
                mapper.modificar(objH);
            }
            return res;
        }

        public Resultado eliminar(Horario objH)
        {
            var res = new Resultado();
            if (objH.dia.Equals(String.Empty))
            {
                res.errores.Add("No puede ser caca");
            }
            else
            {
                mapper.eliminar(objH);
            }
            return res;
        }

        public List<Horario> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
        public Horario obtenerPorId(int xId)
        {
            return mapper.obtenerPorId(xId);
        }
    }
}
