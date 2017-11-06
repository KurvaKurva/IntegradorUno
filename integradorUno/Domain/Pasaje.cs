using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pasaje
    {
        public List<string> listaTramos = new List<string>();
        public Tramo objT { get; set; }
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }        
        public Ciudad objC { get; set; }
        public Horario objH { get; set; }
        public DateTime fecha { get; set; }
        public Omnibus objO { get; set; }
        public int costo { get; set; }
    }
}
