using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
    public interface iHorario
    {
        List<Horario> obtenerTodos();
        Horario obtenerPorId(int xId);
    }
}
