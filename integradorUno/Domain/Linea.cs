using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Linea
    {
        public int id { get; set; }
        public Tramo objT { get; set; }
        public Pasaje objP { get; set; }
    }
}
