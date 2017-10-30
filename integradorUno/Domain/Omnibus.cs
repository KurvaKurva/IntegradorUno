using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Omnibus
    {
        public string matricula { get; set; }
        public int capacidad { get; set; }
        public Ciudad ciudadActual { get; set; }
        public bool isLleno { get; set; }

    }
}
