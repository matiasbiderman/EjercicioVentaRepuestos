using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class StockNegativoException : Exception
    {
        public StockNegativoException() : base("El repuesto no puede quedar con un stock negativo") { }
    }
}
