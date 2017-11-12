using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using interfacesMapeo;

namespace Servicios
{
    public class gestoraLinea
    {
        public static iLinea mapper { get; set; }
        public Resultado agregarLinea(Tramo objT)
        {
            var resultado = new Resultado();
            if (objT.id < 0)
            {
                resultado.errores.Add("El nombre no puede estar vacío");
            }
            else
            {
                mapper.guardar(objT);
            }
            return resultado;
        }

        public List<Linea> obtenerTodos()
        {
            return mapper.obtenerTodos();
        }

        public List<Linea> obtenerTramosPorPasaje(int xId)
        {
            return mapper.obtenerTramosPorPasaje(xId);
        }
    }
}
