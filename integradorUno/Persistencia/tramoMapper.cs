using interfacesMapeo;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class tramoMapper :MapperBase, iTramo
    {
        private Tramo cargarTramo(SqlDataReader reader)
        {
            var objT = new Tramo();
            var objCorigen = new Ciudad();
            var objDestino = new Ciudad();
            objT.id = Convert.ToInt32(reader["id"]);
            objT.cantKilometros = Convert.ToInt32(reader["cantKilometros"]);
            objT.precioBase = Convert.ToInt32(reader["precioBase"]);
            //objT.origen.nombre = Convert.ToString(reader["ciudadOrigen"]);
            //objT.destino.nombre = Convert.ToString(reader["ciudadDestino"]);
            var ciudadOrigen = new ciudadMapper().obtenerPorId(objCorigen.id);
            var ciudadDestino = new ciudadMapper().obtenerPorId(objDestino.id);
            return objT;
        }


        #region Obtener
        public List<Tramo> obtenerTodos()
        {
            List<Tramo> listaTramo = new List<Tramo>();
            var param = new List<SqlParameter>();
            var con = AbrirConexion();
            var reader = select("SELECT * FROM tramo", CommandType.Text, param, con, null);
            while(reader.Read())
            {
                listaTramo.Add(cargarTramo(reader));
            }
            CerrarConexion(con);
            return listaTramo;
        }

        public Tramo obtenerPorId(int xId)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = xId;
            param.Add(id);
            var con = AbrirConexion();
            var reader = select("SELECT * FROM tramo WHERE id = @id", CommandType.Text, param, con, null);
            Tramo t = null;
            {
                if (reader.Read())
                {
                    t = cargarTramo(reader);
                }
                CerrarConexion(con);
                return t;
            }
        }
        #endregion


        #region ABM
        public void guardar(Tramo objT, Ciudad origen, Ciudad destino)
        {
            var param = new List<SqlParameter>();
            var cantKilometros = new SqlParameter();
            var precioBase = new SqlParameter();
            var ciudadOrigen = new SqlParameter();
            var ciudadDestino = new SqlParameter();
            ciudadOrigen.ParameterName = "@ciudadOrigen";
            ciudadOrigen.Value = origen.id;
            ciudadDestino.ParameterName = "@ciudadDestino";
            ciudadDestino.Value = destino.id;
            cantKilometros.ParameterName = "@cantKilometros";
            cantKilometros.Value = objT.cantKilometros;
            precioBase.ParameterName = "@precioBase";
            precioBase.Value = objT.precioBase;
            param.Add(cantKilometros);
            param.Add(precioBase);
            param.Add(ciudadOrigen);
            param.Add(ciudadDestino);
            var con = AbrirConexion();
            var tran = con.BeginTransaction();
            try
            {
                var resultado = EjecutaNonQuery("INSERT INTO tramo (cantKilometros, precioBase, ciudadOrigen, ciudadDestino) VALUES (@cantKilometros, @precioBase, @ciudadOrigen, @ciudadDestino)", CommandType.Text, param, con, tran);
                tran.Commit();
            }
            catch(Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                CerrarConexion(con);
            }
        }

        public int eliminar(Tramo objT)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = objT.id;
            param.Add(id);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("DELETE FROM tramo WHERE id = @id", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        }

        public int modificar(Tramo objT)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            var cantKilometros = new SqlParameter();
            var precioBase = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = objT.id;
            cantKilometros.ParameterName = "@cantKilometros";
            cantKilometros.Value = objT.cantKilometros;
            precioBase.ParameterName = "@precioBase";
            precioBase.Value = objT.precioBase;
            param.Add(id);
            param.Add(cantKilometros);
            param.Add(precioBase);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("UPDATE tramo SET cantKilometros = @cantKilometros , precioBase = @precioBase WHERE id = @id", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        }
        #endregion      
    }
}
