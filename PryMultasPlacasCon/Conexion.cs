using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;

namespace PryMultasPlacasCon
{

    public class Conexion
    {

        private string Cadena;

        public Conexion(string CadenaConexion)
        {
            this.Cadena = CadenaConexion;
        }

        public static string getConnectionOleDBString()
        {
            return ConfigurationManager.ConnectionStrings["MultasPlacasConnection"].ConnectionString;
        }

        public static SqlConnection getConnection()
        {

            string strcnx = getConnectionOleDBString();
            SqlConnection conn = new SqlConnection(strcnx);
            conn.Open();
            return conn;

        }

        public DataTable EjecutarQuery(string Query)
        {
            DataTable Rpta = new DataTable();
            SqlConnection sqlConnection1 = new SqlConnection(Cadena);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            Rpta.Load(reader);
            sqlConnection1.Close();
            return Rpta;
        }

        public  DataTable EjecutarProcedure(string spName, ArrayList alParametros)
        {
            try
            {
                SqlConnection conn = getConnection();
                SqlCommand cmd = getCommand_Odbc1(conn, spName, alParametros);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }


        private static SqlCommand getCommand_Odbc1(SqlConnection conn, string spName, ArrayList alParametros)
        {
            SqlCommand cmd = new SqlCommand(spName, conn);

            IEnumerator ieParametros = alParametros.GetEnumerator();
            while (ieParametros.MoveNext())
            {
                cmd.Parameters.Add((SqlParameter)ieParametros.Current);
            }
            return cmd;
        }

        public DataSet EjecutarProcedureDS(string procedure, Parametros paramst)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(procedure, Cadena);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (Parametro param in paramst.getParametros()) {
                    da.SelectCommand.Parameters.Add(param.Nombre);
                    da.SelectCommand.Parameters[param.Nombre].Value = param.Valor;
                }

               

                da.Fill(ds);
                da.Dispose();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }
    }
}
