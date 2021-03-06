﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Persistencia
{
    public abstract class MapperBase
    {
        public static string StringConexionBD
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            }
        }
        public static int EjecutaNonQuery(string sentencia, CommandType tipoComando, List<SqlParameter> parametros, SqlConnection con, SqlTransaction trn)
        {
            int afectadas = -1;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sentencia;
                cmd.CommandType = tipoComando;
                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros.ToArray());
                }
                if (trn != null)
                    cmd.Transaction = trn;
                afectadas = cmd.ExecuteNonQuery();

            }
            return afectadas;
        }

        public static object ejecutaScalar(string sentencia, CommandType tipoComando, List<SqlParameter> parametros, SqlConnection con, SqlTransaction trn)
        {
            object retorno;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sentencia;
                cmd.CommandType = tipoComando;
                cmd.Parameters.AddRange(parametros.ToArray());
                if (trn != null)
                    cmd.Transaction = trn;
                retorno = cmd.ExecuteScalar();

            }

            return retorno;
        }

        public static SqlDataReader select(string sentencia, CommandType tipoComando, List<SqlParameter> parametros, SqlConnection con, SqlTransaction trn)
        {

            if (con == null)
            {
                con = AbrirConexion();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sentencia;
            cmd.CommandType = tipoComando;
            if (parametros != null)
                cmd.Parameters.AddRange(parametros.ToArray());

            if (con.State == ConnectionState.Closed)
                con.Open();

            if (trn != null)
                cmd.Transaction = trn;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }

        private static string _servidor = "DESKTOP-6BB7657";
        private static string _baseDatos = "integradorUnoPrueba";
        private static string dataConexion = "Data Source=" + _servidor + ";Initial Catalog=" + _baseDatos + ";" + "Integrated Security=SSPI;";
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection(dataConexion);
            return conn;
        }

        public static SqlConnection AbrirConexion()
        {
            SqlConnection con = ObtenerConexion();
            con.Open();
            return con;
        }

        public static void CerrarConexion(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
