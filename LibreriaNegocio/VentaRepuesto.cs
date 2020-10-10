using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    public class VentaRepuesto
    {
        List<Repuesto> _listaRepuestos;
        private string _nombreComercio = "";
        private string _direccion = "";


        public VentaRepuesto(string nombre, string direccion)
        {
            this._nombreComercio = nombre;
            this._direccion = direccion;
            _listaRepuestos = new List<Repuesto>();
        }

        public string NombreComercio
        {
            get
            {
                return this._nombreComercio;
            }
        }

        public string Direccion
        {
            get
            {
                return this._direccion;
            }
        }

        public bool getCodigoExistente(int codigo)
        {
            bool encuentra = false;
            foreach (Repuesto rep in _listaRepuestos)
            {
                if (codigo == rep.CodigoRepuesto)
                {
                    encuentra = true;
                }
            }
            return encuentra;
        }
        public void AgregarRepuesto(Repuesto repuesto)
        {
            if (getCodigoExistente(repuesto.CodigoRepuesto))
            {
                throw new CodigoExistenteException();
            }
            else
            {
                _listaRepuestos.Add(repuesto);
            }
        }

        public Repuesto TraerRepuestoByCodigo(int codigo)
        {
            Repuesto repuesto = null;
            foreach (Repuesto rep in _listaRepuestos)
            {
                if (codigo == rep.CodigoRepuesto)
                {
                    repuesto = rep;
                }
            }
            if (repuesto == null)
                throw new RepuestoExistenteException();

            return repuesto;
        }
        public void QuitarRepuesto(int codigo)
        {
            if (getCodigoExistente(codigo))
            {
                _listaRepuestos.Remove(TraerRepuestoByCodigo(codigo));
            }
            else
            {
                throw new Exception("El codigo es invalido");
            }
        }
        public void ModificarPrecio(int codigo, double precio)
        {
            Repuesto rep = TraerRepuestoByCodigo(codigo);
            rep.Precio = precio;
        }
        public void AgregarStock(int codigo, int stock)
        {
            Repuesto rep = TraerRepuestoByCodigo(codigo);
            rep.Stock = rep.Stock + stock;
        }
        public void QuitarStock(int codigo, int stock)
        {
            Repuesto rep = TraerRepuestoByCodigo(codigo);
            if (rep.Stock > 0)
            {
                if (stock < rep.Stock)
                {
                    rep.Stock = rep.Stock - stock;
                }
                else
                {
                    throw new StockNegativoException();
                }
            }
            else
            {
                throw new Exception("El repuesto cuenta con stock, no se puede eliminar");
            }
        }
        public void ModificarRepuesto(Repuesto repuestoNuevo)
        {
            bool encuentra = false;
            for (int i = 0; i < _listaRepuestos.Count; i++)
            {
                if (_listaRepuestos[i].CodigoRepuesto == repuestoNuevo.CodigoRepuesto)
                {
                    _listaRepuestos[i] = repuestoNuevo;
                    encuentra = true;
                }
            }
            if (encuentra == false)
                throw new Exception("No puedo modificar");

        }
        public string ListarRepuestos()
        {
            string lista = "";
            foreach (Repuesto repuesto in _listaRepuestos)
            {
                lista += repuesto.ToString() + "\n";
            }
            if (lista == "")
            {
                throw new RepuestoExistenteException();
            }
            return lista;
        }
        private List<Repuesto> TraerPorCategoria(int codigoCat)
        {
            List<Repuesto> lista = new List<Repuesto>();
            foreach (Repuesto rep in _listaRepuestos)
            {
                if (codigoCat == rep.CodigoCategoria)
                {
                    lista.Add(rep);
                }
            }
            return lista;
        }
        public string ListaPorCategoria(int categoria)
        {
            string retorno = "";
            //for (int i = 1; i < CategoriaHelper.GetCantCategorias(); i++)
            //{
                List<Repuesto> lista = TraerPorCategoria(categoria);
                if (lista.Count >= 1)
                {
                    foreach (Repuesto rep in lista)
                    {
                        retorno = retorno + rep.ToString() + "\n";
                    }
                }
           // }
            if (retorno == "")
            {
                throw new CategoriaExistenteException();
            }
            else
            {
                return retorno;
            }
        }
    }
}
