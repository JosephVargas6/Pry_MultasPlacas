using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryMultasPlacasCon
{
    public class Parametro
    {
        public const int param_Integer = 0;
        public const int param_Varchar = 1;
        public const int param_Decimal = 2;
        public const int param_Datetime = 3;
        public const int param_Binary = 4;

        private string _nombre;
        private object _tipoValor;
        private object _valor;
        private int _PriLong;
        private int _SubLong;
        public Parametro(object Tipo, string nombre, object valor, int PriLong, int subLong = 0)
        {
            this._tipoValor = Tipo;
            this._nombre = nombre;
            this._valor = valor;
            this._PriLong = PriLong;
            this._SubLong = subLong;
        }

        public object tipo
        {
             get;
            private set;
        }

        public string Nombre
        {
            get;
            private set;
        }

        public object Valor
        {
            get;

            private set;
        }

        public int PriLongitud
        {
            get;
            private set;
        }

        public int SubLongitud
        {
            get;
            private set;
        }
    }
}
