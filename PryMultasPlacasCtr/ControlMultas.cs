using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PryMultasPlacasCon;
using PryMultasPlacasEnt;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace PryMultasPlacasCtr
{

 

    public class ControlMultas
    {

        private Conexion conexion;

        public ControlMultas(Conexion conexion)
        {
            this.conexion = conexion;
        }




        public List<Multas> mListarPlacas (string placa, string maxRows,string pagina, string colNombre, string colOrden)
        {
            ArrayList paramrs = new ArrayList();

            SqlParameter sqlparametro = new SqlParameter("@placa", SqlDbType.NVarChar, 20);
            sqlparametro.Value = placa;
            paramrs.Add(sqlparametro);
            sqlparametro = new SqlParameter("@inMaxRows", SqlDbType.NVarChar, 20);
            sqlparametro.Value = maxRows;
            paramrs.Add(sqlparametro);
            sqlparametro = new SqlParameter("@inPagina", SqlDbType.NVarChar, 20);
            sqlparametro.Value = pagina;
            paramrs.Add(sqlparametro);
            sqlparametro = new SqlParameter("@colNombre", SqlDbType.NVarChar, 128);
            sqlparametro.Value = colNombre;
            paramrs.Add(sqlparametro);
            sqlparametro = new SqlParameter("@colOrden", SqlDbType.NVarChar, 10);
            sqlparametro.Value = colOrden;
            paramrs.Add(sqlparametro);
           
            DataTable dt = conexion.EjecutarProcedure("usp_ConsultarPlacasMultas",paramrs);


            Multas OMultas = new Multas();
            List<Multas> lstmultas = new List<Multas>();
           


            foreach (DataRow rw in dt.Rows)
            {
                OMultas = new Multas();
                OMultas.placa = rw[0].ToString();
                OMultas.falta = rw[1].ToString();
                OMultas.fecfraccion = rw[2].ToString();
                OMultas.importe = rw[3].ToString();
                OMultas.estado = rw[4].ToString();
                OMultas.paginas = rw[5].ToString();
                lstmultas.Add(OMultas);


            }
            return lstmultas;
        }


    }
}
