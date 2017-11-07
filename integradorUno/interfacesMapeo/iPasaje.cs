using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
    public interface iPasaje
    {
        void guardar(Pasaje objP, Omnibus objO, Horario objH, Ciudad origen, Ciudad destino);
        List<Pasaje> obtenerTodos();
    }
}
