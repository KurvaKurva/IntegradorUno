using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
    public interface iLinea
    {
        List<Linea> obtenerTodos();
        void guardar(Tramo objT);
        List<Linea> obtenerTramosPorPasaje(int xId);
    }
}
