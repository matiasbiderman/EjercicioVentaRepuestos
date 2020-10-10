using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class CodigoExistenteException : Exception
    {
        public CodigoExistenteException() : base("el codigo ya existe") { }
    }
}
