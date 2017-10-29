using interfacesMapeo;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class ciudadMapper: MapperBase, iCiudad
    {
        private Ciudad cargarCiudades(SqlDataReader reader)
        {
            var ciudad = new Ciudad();
            ciudad.id = Convert.ToInt32(reader["id"]);
            ciudad.nombre = Convert.ToString(reader["nombre"]);
            return ciudad;
        }

        /*public void guardarCiudad(Ciudad objC)
        {
            var parametros = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = objC.id;
            parametros.Add(id);
            var nombre = new SqlParameter();
            nombre.ParameterName = "@nombre";
            nombre.Value = objC.nombre;
            parametros.Add(nombre);
            var con = AbrirConexion();
            var trn = con.BeginTransaction();
            try
            {
                var filasAfectadas = EjecutaNonQuery("INSERT INTO ciudad (nombre) VALUES (@nombre);", CommandType.Text, parametros, con, trn);

            }
        }*/
    }
}
