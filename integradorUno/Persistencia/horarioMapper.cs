using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class horarioMapper : MapperBase, iHorario
    {
        private Horario cargarHorario(SqlDataReader reader)
        {
            var objH = new Horario();
            var objT = new Tramo();
            var objO = new Omnibus();
            objH.id = Convert.ToInt32(reader["id"]);
            objH.horarioSalida = Convert.ToString(reader["horarioSalida"]);
            objH.horarioLlegada = Convert.ToString(reader["horarioLlegada"]);
            objH.dia = Convert.ToString(reader["dia"]);
            var omnibus = new omnibusMapper().obtenerPorId(objO.id);
            var tramo = new tramoMapper().obtenerPorId(objT.id);
            return objH;
        }

        /*private Dia cargarDia(SqlDataReader reader)
        {
            var objD = new Dia;

        }*/

        #region Obtener
        public List<Horario> obtenerTodos()
        {
            List<Horario> listaHorarios = new List<Horario>();
            var param = new List<SqlParameter>();
            var con = AbrirConexion();
            var reader = select("SELECT * FROM horario", CommandType.Text, param, con, null);
            while (reader.Read())
            {
                listaHorarios.Add(cargarHorario(reader));
            }
            CerrarConexion(con);
            return listaHorarios;
        }

        public Horario obtenerPorId(int xId)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = xId;
            param.Add(id);
            var con = AbrirConexion();
            var reader = select("SELECT * FROM horario WHERE id = @id", CommandType.Text, param, con, null);
            Horario h = null;
            if (reader.Read())
            {
                h = cargarHorario(reader);
            }
            CerrarConexion(con);
            return h;
        }
        #endregion

        #region ABM
        public void guardar(Horario objH, Omnibus objB, Tramo objT)
        {
            var param = new List<SqlParameter>();
            var horarioSalida = new SqlParameter();
            horarioSalida.ParameterName = "@horarioSalida";
            horarioSalida.Value = objH.horarioSalida;
            param.Add(horarioSalida);
            var horarioLlegada = new SqlParameter();
            horarioLlegada.ParameterName = "@horarioLlegada";
            horarioLlegada.Value = objH.horarioLlegada;
            param.Add(horarioLlegada);
            var dia = new SqlParameter();
            dia.ParameterName = "@dia";
            dia.Value = objH.dia;
            param.Add(dia);
            var tramo = new SqlParameter();
            tramo.ParameterName = "@idTramo";
            tramo.Value = objT.id;
            param.Add(tramo);
            var omnibus = new SqlParameter();
            omnibus.ParameterName = "@idOmnibus";
            omnibus.Value = objB.id;
            param.Add(omnibus);
            var con = AbrirConexion();
            var trn = con.BeginTransaction();
            try
            {
                var filasAfectadas = EjecutaNonQuery("INSERT INTO horario (horarioSalida, horarioLlegada, dia, idTramo, idOmnibus)VALUES (@horarioSalida, @horarioLlegada, @dia, @idTramo, @idOmnibus)", CommandType.Text, param, con, trn);
                
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

        public int modificar(Horario objH)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = objH.id;
            param.Add(id);
            var horarioSalida = new SqlParameter();
            horarioSalida.ParameterName = "@horarioSalida";
            horarioSalida.Value = objH.horarioSalida;
            param.Add(horarioSalida);
            var horarioLlegada = new SqlParameter();
            horarioLlegada.ParameterName = "@horarioLlegada";
            horarioLlegada.Value = objH.horarioLlegada;
            param.Add(horarioLlegada);
            var dia = new SqlParameter();
            dia.ParameterName = "@dia";
            dia.Value = objH.dia;
            param.Add(dia);
            var tramo = new SqlParameter();
            tramo.ParameterName = "@idTramo";
            tramo.Value = objH.objT.id;
            param.Add(tramo);
            var omnibus = new SqlParameter();
            omnibus.ParameterName = "@idOmnibus";
            omnibus.Value = objH.objO.id;
            param.Add(omnibus);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("UPDATE horario SET horarioSalida = @horarioSalida, horarioLlegada = @horarioLlegada, dia = @dia, idTramo = @idTramo, idOmnibus = @idOmnibus WHERE id = @id", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        } 

        public int eliminar(Horario objH)
        {
            var param = new List<SqlParameter>();
            var id = new SqlParameter();
            id.ParameterName = "@id";
            id.Value = objH.id;
            param.Add(id);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("DELETE FROM horario WHERE id = @id", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        }

        #endregion
    }
}
