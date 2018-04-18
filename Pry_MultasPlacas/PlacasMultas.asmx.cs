using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PryMultasPlacasCon;
using PryMultasPlacasCtr;
using System.Web.Script.Services;

namespace Pry_MultasPlacas
{
    /// <summary>
    /// Summary description for PlacasMultas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PlacasMultas : System.Web.Services.WebService
    {

        private ControlMultas oControlMultas;

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public Object wsListarPlacas(string placa, string maxRows, string pagina, string colNombre, string colOrden)
        {
            ConexionSPC cn = new ConexionSPC();
            oControlMultas = new ControlMultas(cn);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(oControlMultas.mListarPlacas(placa,maxRows,pagina,colNombre,colOrden));
        }
    }
}
