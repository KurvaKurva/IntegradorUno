using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pasaje
    {        
        public int id { get; set; }
        public Linea objL { get; set; }
        public Ciudad origen { get; set; }
        public Ciudad destino { get; set; }    
        public Horario objH { get; set; }
        public DateTime fecha { get; set; }
        public Omnibus objO { get; set; }
        public int costo { get; set; }

      /*  public string datos
        {
            get { return "Origen: " + origen.nombre + " Destino: " + destino.nombre + " Fecha: " + fecha + " Horario: " + objH.datos + " Servicio: " + objO.matricula + " Costo: " + costo; }
        }*/
        public string datos
        {
            get { return "Costo: " + costo; }
        }
    }
}
