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
        void guardar(Omnibus objO, Ciudad objC);
    }
}
