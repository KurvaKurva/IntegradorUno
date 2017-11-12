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

        public Resultado agegarPasaje(Pasaje objP, Omnibus objO, Horario objH, Ciudad origen, Ciudad destino, Linea objL)
        {
            var resultado = new Resultado();
            if (objP.costo < 0)
            {
                resultado.errores.Add("El costo debe ser mayor a 0.");
            }
            else if (objO.isLleno == true)
            {
                resultado.errores.Add("El servicio está lleno.");
            }
            else if (!verificarServicioSeEncuentraEnCiudadOrigen(objO, origen))
            {
                resultado.errores.Add("La ciudad de origen debe ser la ciudad actual del servicio.");
            }
            else if(!verificarOrigenDestinoDiferentes(origen, destino))
            {
                resultado.errores.Add("La ciudad de origen y la de destino no pueden ser iguales");
            }
            else
            {
                mapper.guardar(objP, objO, objH, origen, destino, objL);
            }
            return resultado;
        }

        public bool verificarServicioSeEncuentraEnCiudadOrigen(Omnibus objOm, Ciudad objCi)
        {
            var objO = new gestoraOminubs().obtenerPorId(objOm.id);
            var objC = new gestoraCiudad().obtenerPorId(objCi.id);
            if(objO.ciudadActual.id == objCi.id)
            {
                return false;
            }
            return true;
        }
        public bool verificarOrigenDestinoDiferentes(Ciudad origen, Ciudad destino)
        {
            if(origen.id == destino.id)
            {
                return false;
            }
            return true;
        }
        public List<Pasaje> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }

        public List<Pasaje> obtenerPasajesEntreFechas(int xIdTramo, DateTime xFechaInicio, DateTime xFechaFin)
        {
            return mapper.obtenerPasajesEntreFechas(xIdTramo, xFechaInicio, xFechaFin);
        }
       /* public int obtenerCostoTotalPasaje(int xIdPasaje, Tramo objT)
        {
            var lstPasajes = obtener
        }
        */
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
