using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class pasajeMapper:MapperBase, iPasaje
    {
        private Pasaje cargarPasaje(SqlDataReader reader)
        {
            var objP = new Pasaje();
            var objO = new Omnibus();
            var objH = new Horario();
            var objC = new Ciudad();
            var objT = new Tramo();
            objP.fecha = Convert.ToDateTime(reader["fecha"]);
            objP.costo = Convert.ToInt32(reader["costo"]);
            
            var idCiudad = new ciudadMapper().obtenerPorId(objC.id);
            var idHorario = new horarioMapper().obtenerPorId(objH.id);
            var idOmnibus = new omnibusMapper().obtenerPorId(objO.id);
            return objP;
        }

        public List<Pasaje> obtenerTodos()
        {
            List<Pasaje> listaPasajes = new List<Pasaje>();
            var param = new List<SqlParameter>();
            var con = AbrirConexion();
            var reader = select("SELECT * FROM pasaje", CommandType.Text, param, con, null);
            while (reader.Read())
            {
                listaPasajes.Add(cargarPasaje(reader));
            }
            CerrarConexion(con);
            return listaPasajes;
        }

        #region ABM

        public void guardar(Pasaje objP, Omnibus objO, Horario objH, Ciudad objC)
        {
            var param = new List<SqlParameter>();
            var costo = new SqlParameter();
            costo.ParameterName = "@costo";
            costo.Value = objP.costo;
            param.Add(costo);
            var fecha = new SqlParameter();
            fecha.ParameterName = "@fecha";
            fecha.Value = objP.fecha;
            param.Add(fecha);
            var idOmnibus = new SqlParameter();
            idOmnibus.ParameterName = "@idOmnibus";
            idOmnibus.Value = objO.id;
            param.Add(idOmnibus);
            var origen = new SqlParameter();
            origen.ParameterName = "@idCiudadOrigen";
            origen.Value = objC.id;
            param.Add(origen);
            var destino = new SqlParameter();
            destino.ParameterName = "@idCiudadDestino";
            destino.Value = objC.id;
            param.Add(destino);
            var horario = new SqlParameter();
            horario.ParameterName = "@idHorario";
            horario.Value = objH.id;
            param.Add(horario);
            var con = AbrirConexion();
            var trn = con.BeginTransaction();
            try
            {
                var filasAfectadas = EjecutaNonQuery("INSERT INTO pasaje costo, fecha, idOmnibus, idHorario, ciudadOrigen, ciudadDestino VALUES @costo, @fecha, @idOmnibus, @idHorario, @idCiudadOrigen, @idCiudadDestino", CommandType.Text, param, con, trn);
                trn.Commit();
            }
            catch(Exception ex)
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
