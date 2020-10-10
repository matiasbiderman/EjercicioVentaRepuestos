using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class Categoria
    {
        private int _codigo;
        private string _nombre;

        public Categoria(int codigo, string nombre)
        {
            this._codigo = codigo;
            this._nombre = nombre;
        } 
        public int CodigoCategoria
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public string NombreCategoria
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public override string ToString()
        {
            return "Codigo Categoria:  " + this._codigo + "\t" + "Nombre Categoria:  " +  this._nombre + "\n";
        }
    }
}
