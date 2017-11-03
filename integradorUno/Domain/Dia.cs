using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Dia
    {
        int id { get; set; }
        string nombre { get; set; }
        List<Horario> listaHorarios { get; set; }
    }
}
