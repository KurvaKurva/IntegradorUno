using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
   public interface iOmnibus
    {
        List<Omnibus> obtenerTodos();
        Omnibus obtenerPorMatricula(string xMatricula);
        void guardar(Omnibus objO, Ciudad objC);

        int modificar(Omnibus objO);
        int eliminar(Omnibus objO);
    }
}
