using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using interfacesMapeo;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class omnibusMapper
    {
        private Omnibus cargarOmnibus(SqlDataReader reader)
        {
            var objO = new Omnibus();
            var objC = new Ciudad();
            objO.capacidad = Convert.ToInt32(reader["capacidad"]);
            objO.matricula = Convert.ToString(reader["matricula"]);
            objO.isLleno = Convert.ToBoolean(reader["isLleno"]);            
            var ciudad = new ciudadMapper().obtenerPorId(objC.id);
            return objO;
        }
    }
}
