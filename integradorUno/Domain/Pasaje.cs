using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pasaje
    {
        public List<string> listaTramos = new List<string>();
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }
        public DateTime horaPartida { get; set; }
        public DateTime fechaPartida { get; set; }
        public Omnibus servicio { get; set; }
    }
}
