﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Tramo
    {
        public int id { get; set; }
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }
        public int cantKilometros { get; set; }
        public int precioBase { get; set; }
    }
}
