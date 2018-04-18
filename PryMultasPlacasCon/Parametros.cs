using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryMultasPlacasCon
{
    public class Parametros
    {

        private List<Parametro> _params;

        public Parametros()
        {
            _params = new List<Parametro>();
        }

        public void AddParametro(Parametro param)
        {
            _params.Add(param);
        }

        public List<Parametro> getParametros()
        {
            return _params;
        }
    }
}
