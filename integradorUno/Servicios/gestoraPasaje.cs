using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using interfacesMapeo;

namespace Servicios
{
    public class gestoraPasaje
    {
        public static iPasaje mapper { get; set; }
        
        public Resultado agegarPasaje(Pasaje objP, Omnibus objO, Horario objH, Ciudad origen, Ciudad destino)
        {
            var resultado = new Resultado();
            if (objP.costo == 0)
            {
                resultado.errores.Add("El nombre no puede estar vacío");
            }
            else
            {
                mapper.guardar(objP, objO, objH, origen, destino);
            }
            return resultado;
        }

        public List<Pasaje> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }

        public List<Pasaje> obtenerPasajesEntreFechas(int xIdTramo, DateTime xFechaInicio, DateTime xFechaFin)
        {
            return mapper.obtenerPasajesEntreFechas(xIdTramo, xFechaInicio, xFechaFin);
        }

        public int obtenerCostoTotalDePasajesSegunTramoYFechas(int xIdTramo, DateTime xFechaInicio, DateTime xFechaFin)
        {
            var lstPasajes = obtenerPasajesEntreFechas(xIdTramo, xFechaInicio, xFechaFin);
            var total = 0;
            foreach (var objP in lstPasajes)
            {   
                total = total + objP.costo;
            }
            return total;
        }
    }
}
