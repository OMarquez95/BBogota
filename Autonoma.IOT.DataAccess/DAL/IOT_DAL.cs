using Autonoma.IOT.Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace Autonoma.IOT.DataAccess.DAL
{
    public class IOT_DAL
    {
        private static IOT_DAL instance = null;
        private MySqlConnection connection;

        /// <summary>
        /// Constructor privado que retorna un objeto del mismo tipo
        /// </summary>
        /// <param name="connectionString"></param>
        private IOT_DAL(String connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
            connection.Open();

        }

        /// <summary>
        /// Método privado que asegura una única instancia de conexión a la base de datos - SINGLETON
        /// </summary>
        /// <returns>Una instancia de IOT_DAL</returns>
        public static IOT_DAL GetInstance(String connectionString)
        {
            if(instance == null)
            {
                instance = new IOT_DAL(connectionString);
                
            }
            return instance;
        }

       

        /// <summary>
        /// Método que permite obtener un cursor de salida de la ejecución de query selext
        /// </summary>
        /// <param name="query">query a ejecutar</param>
        /// <returns>DataTable con el cursor de salida del query</returns>
        public DataTable ExecuteQuery(string query)
        {
            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message, e.InnerException);
            }
            finally {
                connection.Close();
            }
        }

        /// <summary>
        /// Método que permite hacer un insert, update, or delete
        /// </summary>
        /// <param name="query">query a ejecutar</param>
        /// <returns>true or false of transaction</returns>
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                if (cmd.ExecuteNonQuery() == 1)                    
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message, e.InnerException);
            }
            finally {
                connection.Close();
            }
        }        

        /// <summary>
        /// Método que libera los recursos de la conexión
        /// </summary>
        public void Dispose()
        {
            connection.Dispose();
        }

        /// <summary>
        /// Método que cierra la conexión a la base de datos
        /// </summary>
        public void Close()
        {
            connection.Close();
        }
    }
}
