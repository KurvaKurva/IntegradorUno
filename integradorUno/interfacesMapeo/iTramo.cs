using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
    public interface iTramo
    {
        List<Tramo> obtenerTodos();
        Tramo obtenerPorId(int xId);
        void guardar(Tramo objT);
        int eliminar(Tramo objT);
        int modificar(Tramo objT);
    }
}
