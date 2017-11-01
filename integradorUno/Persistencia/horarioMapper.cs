using System;
using System.Collections.Generic;
using System.Text;
using interfacesMapeo;
using Dominio;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class horarioMapper:MapperBase, iHorario
    {
        private Horario cargarHorario(SqlDataReader reader)
        {
            var objH = new Horario();
            var objT = new Tramo();
            var objO = new Omnibus();
            objH.id = Convert.ToInt32(reader["id"]);
            objH.horarioSalida = Convert.ToDateTime(reader["horarioSalida"]);
            objH.horarioLlegada = Convert.ToDateTime(reader["horarioLlegada"]);
            var omnibus = new omnibusMapper().obtenerPorId(objO.id);
            var tramo = new tramoMapper().obtenerPorId(objT.id);
            return objH;

        }

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
            if(reader.Read())
            {
                h = cargarHorario(reader);
            }
            CerrarConexion(con);
            return h;
        }
        #endregion
    }
}
