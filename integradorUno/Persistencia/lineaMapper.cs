using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;
using interfacesMapeo;

namespace Persistencia
{
    public class lineaMapper:MapperBase, iLinea
    {
        private Linea cargarLinea(SqlDataReader reader)
        {
            var objL = new Linea();
            var objT = new Tramo();
            var objP = new Pasaje();

            objL.objT = new Tramo() { id = Convert.ToInt32(reader["idTramo"]) };
            objL.objP = new Pasaje() { id = Convert.ToInt32(reader["idPasaje"]) };
            return objL;
        }

        #region Obtener
        public List<Linea> obtenerTodos()
        {
            List<Linea> listaLineas = new List<Linea>();
            var param = new List<SqlParameter>();
            var con = AbrirConexion();
            var reader = select("SELECT * FROM linea", CommandType.Text, param, con, null);
            while (reader.Read())
            {
                listaLineas.Add(cargarLinea(reader));
            }
            CerrarConexion(con);
            return listaLineas;
        }
        #endregion

        #region ABM
        public void guardar(Tramo objT, Pasaje objP)
        {
            var param = new List<SqlParameter>();
            var idTramo = new SqlParameter();
            idTramo.ParameterName = "@idTramo";
            idTramo.Value = objT.id;
            param.Add(idTramo);
            var idPasaje = new SqlParameter();
            idPasaje.ParameterName = "@idPasaje";
            idPasaje.Value = objP.id;
            param.Add(idPasaje);            
            var con = AbrirConexion();
            var trn = con.BeginTransaction();
            try
            {
                var filasAfectadas = EjecutaNonQuery("INSERT INTO linea (idTramo, idPasaje) VALUES (@idTramo, @idPasaje)", CommandType.Text, param, con, trn);
                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
            }
            finally
            {
                CerrarConexion(con);
            }
        }
        #endregion
    }
}
