using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using interfacesMapeo;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class omnibusMapper : MapperBase, iOmnibus
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

        #region Obtener
        public List<Omnibus> obtenerTodos()
        {
            List<Omnibus> listaOmnibus = new List<Omnibus>();
            var param = new List<SqlParameter>();
            var con = AbrirConexion();
            var reader = select("SELECT * FROM omnibus", CommandType.Text, param, con, null);
            while (reader.Read())
            {
                listaOmnibus.Add(cargarOmnibus(reader));
            }
            CerrarConexion(con);
            return listaOmnibus;
        }

        public Omnibus obtenerPorMatricula(string xMatricula)
        {
            var param = new List<SqlParameter>();
            var matricula = new SqlParameter();
            matricula.ParameterName = "@matricula";
            matricula.Value = xMatricula;
            param.Add(matricula);
            var con = AbrirConexion();
            var reader = select("SELECT * FROM omnibus WHERE matricula = @matricula", CommandType.Text, param, con, null);
            Omnibus o = null;
            if (reader.Read())
            {
                o = cargarOmnibus(reader);
            }
            CerrarConexion(con);
            return o;
        }
        #endregion

        #region ABM
        public void guardar(Omnibus objO, Ciudad objC)
        {
            var param = new List<SqlParameter>();
            var matricula = new SqlParameter();
            matricula.ParameterName = "@matricula";
            matricula.Value = objO.matricula;
            param.Add(matricula);
            var capacidad = new SqlParameter();
            capacidad.ParameterName = "@capacidad";
            capacidad.Value = objO.capacidad;
            param.Add(capacidad);
            var ciudad = new SqlParameter();
            ciudad.ParameterName = "@idCiudad";
            ciudad.Value = objC.id;
            param.Add(ciudad);
            var isLleno = new SqlParameter();
            isLleno.ParameterName = "@isLleno";
            isLleno.Value = 0;
            param.Add(isLleno);
            var con = AbrirConexion();
            var trn = con.BeginTransaction();
            try
            {
                var filasAfectadas = EjecutaNonQuery("INSERT INTO omnibus (matricula, capacidad, isLleno, idCiudad) VALUES (@matricula, @capacidad, @isLleno, @idCiudad)", CommandType.Text, param, con, trn);
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

        public int modificar(Omnibus objO)
        {
            var param = new List<SqlParameter>();
            var matricula = new SqlParameter();
            matricula.ParameterName = "@matricula";
            matricula.Value = objO.matricula;
            param.Add(matricula);
            var capacidad = new SqlParameter();
            capacidad.ParameterName = "@capacidad";
            capacidad.Value = objO.capacidad;
            param.Add(capacidad);
            var ciudad = new SqlParameter();
            ciudad.ParameterName = "@idCiudad";
            ciudad.Value = objO.ciudadActual.id;
            param.Add(ciudad);
            var isLleno = new SqlParameter();
            isLleno.ParameterName = "@isLleno";
            isLleno.Value = objO.isLleno;
            param.Add(isLleno);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("UPDATE omnibus SET matricula = @matricula, capacidad = @capacidad, idCiudad = @idCiudad, isLleno = @isLleno", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        }

        public int eliminar(Omnibus objO)
        {
            var param = new List<SqlParameter>();
            var matricula = new SqlParameter();
            matricula.ParameterName = "@matricula";
            matricula.Value = objO.matricula;
            param.Add(matricula);
            var con = AbrirConexion();
            var filasAfectadas = EjecutaNonQuery("DELETE FROM omnibus WHERE matricula = @matricula", CommandType.Text, param, con, null);
            CerrarConexion(con);
            return filasAfectadas;
        }
        #endregion
    }
}
