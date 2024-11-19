﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace Cine_Tp.Repositories.Utils
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-ROCIOAG\SQLEXPRESS;Initial Catalog=CINE_NUEVACORDOBA;Integrated Security=True; TrustServerCertificate = True");
        }
        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }
        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                t = null;
            }

            return t;
        }
        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }
        public int ExecuteSPDMLTransact(string sp, List<ParameterSQL>? parametros, SqlConnection cnn, SqlTransaction transaction, object parameterOut = null)
        {
            //TODO:
            return 0;
        }
        public SqlConnection GetConnection()
        {
            //devolver una connection
            return _connection;
        }
    }
}
