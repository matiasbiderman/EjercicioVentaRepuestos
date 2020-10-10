using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaNegocio
{
    
    public static class CategoriaHelper
    {
        private static List<Categoria> _categorias;
        static CategoriaHelper()
        {
            CargaInicialCategorias();
        }
        private static void CargaInicialCategorias()
        {
            _categorias = new List<Categoria>();
            _categorias.Add(new Categoria(1, "Autos"));
            _categorias.Add(new Categoria(2, "Bicicletas"));
            _categorias.Add(new Categoria(3, "Camiones"));
            _categorias.Add(new Categoria(4, "Heladeras"));
        }

        public static int GetCantCategorias()
        {
            return _categorias.Count;
        }
        public static Categoria GetCategorias(int codigo)
        {
            Categoria cate = null;
            for (int i = 0; i < _categorias.Count; i++)
            {
                if(codigo == _categorias[i].CodigoCategoria)
                {
                    cate = _categorias[i];
                }
            }

            if (cate == null)
                throw new CategoriaExistenteException();

            return cate;
        }

        public static string ListarCategorias()
        {
            string lista = "";
            for (int i = 0; i < _categorias.Count; i++)
            {
                lista += _categorias[i].ToString(); 
            }

            return lista;
        }
        /* public List<Categoria> GetCategorias
         {
             get{
                 return this._categorias;
             }
         }*/
    }
}
