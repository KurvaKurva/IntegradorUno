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

        void guardar(Horario objH, Omnibus objO, Tramo objT);
        int modificar(Horario objH);
        int eliminar(Horario objH);
    }
}
