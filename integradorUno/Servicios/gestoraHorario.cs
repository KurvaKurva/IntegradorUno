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
