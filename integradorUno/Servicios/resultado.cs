using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Resultado
    {
        public List<String> errores { get; set; }
        public Resultado()
        {
            errores = new List<string>();
        }
        public bool estaCorrecto
        {
            get { return errores.Count == 0; }
        }
    }
}
