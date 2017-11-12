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
        void guardar(Pasaje objP, Omnibus objO, Horario objH, Ciudad objOrigen, Ciudad objDestino, Linea objL);
        List<Pasaje> obtenerPasajesEntreFechas(int xIdTramo, DateTime xFechaInicio, DateTime xFechaFin);
        List<Pasaje> obtenerTodos();
    }
}
