using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class Repuesto
    {
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;

        public Repuesto (int codigo, string nombre, double precio, int stock, int codigocategoria)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
            this._stock = stock;
            this._categoria = CategoriaHelper.GetCategorias(codigocategoria);
        }

        public int CodigoCategoria
        {
            get
            {
                return this._categoria.CodigoCategoria;
            }
        }
        public int CodigoRepuesto
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

        public string NombreRepuesto
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
        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }
        public int Stock
        {
            get
            {
                return this._stock;
            }
            set
            {
                this._stock = value;
            }
        }

        public override string ToString()
        {
            return "Codigo: " + this._codigo + "\n" + "Nombre: " + this._nombre + "\n" +
                "Precio: " + this._precio + "\n" + "Stock: " + this._stock + "\n" + "Nombre Categoria: " + _categoria.NombreCategoria;
        }
    }
}
