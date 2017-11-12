using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;

namespace Servicios
{
    public class gestoraTramo
    {
        public static iTramo mapper { get; set; }
        public Resultado agregarTramo(Tramo objT, Ciudad origen, Ciudad destino)
        {
            var resultado = new Resultado();
            if (objT.cantKilometros == 0 || objT.cantKilometros < 0)
            {
                resultado.errores.Add("Los kilómetros no pueden ser 0");
            }
            else if(objT.precioBase == 0 || objT.precioBase < 0)
            {
                resultado.errores.Add("El precio debe ser mayor a 0.");
            }
            else if (!verificarOrigenYDestinoDiferentes(objT))
            {
                resultado.errores.Add("El origen y destino no debe coincidir");
            }
            else
            {
                mapper.guardar(objT, origen, destino);
            }
            return resultado;
        }

        public bool verificarOrigenYDestinoDiferentes(Tramo objT)
        {
            if(objT.origen.id == objT.destino.id)
            {
                return false;
            }
            return true;
        }
        public Tramo obtenerPorId(int xId)
        {
            return mapper.obtenerPorId(xId);
        }
        /*public void guardar(Tramo objT)
        {
            mapper.guardar(objT);
        }*/


        public Resultado modificarTramo(Tramo objT)
        {
            var res = new Resultado();
            if(objT.cantKilometros.Equals(0))
            {
                res.errores.Add("El tramo no tiene una cantidad de kilómetros asignada.");
            }
            else
            {
                mapper.modificar(objT);
            }
            return res;
        }
        public int modificar(Tramo objT)
        {
            return mapper.modificar(objT);
        }

        public int eliminar(Tramo objT)
        {
            return mapper.eliminar(objT);
        }
        public List<Tramo> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }
    }

}
