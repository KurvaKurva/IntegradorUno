using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Horario
    {
        public int id { get; set; }
        public string horarioSalida { get; set; }
        public string horarioLlegada { get; set; }
        public Tramo objT { get; set; }
        public Omnibus objO { get; set; }
        public string dia { get; set; }
    }
}
