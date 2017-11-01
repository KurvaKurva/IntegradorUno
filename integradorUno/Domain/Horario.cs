using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Horario
    {
        public int id { get; set; }
        public DateTime horarioSalida { get; set; }
        public DateTime horarioLlegada { get; set; }
        public Tramo objT { get; set; }
        public Omnibus objO { get; set; }
    }
}
