using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class CategoriaExistenteException : Exception
    {
        public CategoriaExistenteException() : base("No existen categorias") { }
    }
}
