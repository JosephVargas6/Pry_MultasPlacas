using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PryMultasPlacasUtl;

namespace PryMultasPlacasCon
{
    public class ConexionSPC : Conexion
    {
       
            public ConexionSPC() : base(Utilitarios.getCadenaConexion("MultasPlacasConnection"))
            {
            }
       
    }
}
