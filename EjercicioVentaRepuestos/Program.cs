using LibreriaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVentaRepuestos
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcionMenu = "";
            const string AgregarRepuesto = "A";
            const string QuitarRepuesto = "B";
            const string CambiarRepuesto = "C";
            const string ListarRepuestos = "D";
            const string ListarRepuestosPorCategoria = "E";
            const string AgregarStock = "F";
            const string QuitarStock = "G";
            const string CambiarPrecio = "H";
            const string Salir = "S";

            VentaRepuesto local = new VentaRepuesto("Fierros Matias", "direccion 123");

            string menu = "Ingre una opcion: \n" +
                AgregarRepuesto + " - Agregar Repuesto \n" +
                QuitarRepuesto + " - Quitar Repuesto \n" +
                 CambiarRepuesto + " - Modificar Repuesto \n" +
                  ListarRepuestos + " - Listar Repuesto \n" +
                   ListarRepuestosPorCategoria + " - Listar Repuestos Por Categoria \n" +
                    AgregarStock + " - Agregar Stock \n" +
                    QuitarStock + " - Quitar Stock \n" +
                    CambiarPrecio + " - Modificar Precio Repuesto \n" +
                    Salir + " - Salir \n";

            do
            {
                opcionMenu = ServValidac.PedirStringNoVac(menu);
                try
                {
                    switch (opcionMenu)
                    {
                        case AgregarRepuesto:
                            InsertarRepuesto(local);
                            break;
                        case QuitarRepuesto:
                            EliminarRepuesto(local);
                            break;
                        case CambiarRepuesto:
                            ModificarRepuesto(local);
                            break;
                        case ListarRepuestos:
                            Console.WriteLine(local.ListarRepuestos());
                            break;
                        case ListarRepuestosPorCategoria:
                            ListarPorCategoria(local);
                            break;
                        case AgregarStock:
                            InsertarStock(local);
                            break;
                        case QuitarStock:
                            EliminarStock(local);
                            break;
                        case CambiarPrecio:
                            ModificarPrecio(local);
                            break;
                        case Salir:
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }
                catch (RepuestoExistenteException r) { Console.WriteLine(r.Message); }

            } while (opcionMenu != Salir);
        }

        private static void InsertarRepuesto(VentaRepuesto local)
        {
            try
            {
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto");
                string nombre = ServValidac.PedirStringNoVac("Ingrese nombre de repuesto");
                double precio = ServValidac.PedirDouble("Ingrese precio de repuesto");
                int stock = ServValidac.PedirInt("Ingrese cantidad de este repuesto que hay en stock");
                int codigocategoria = ServValidac.PedirInt("Ingrese codigo de la categoria a la que pertenece");
                //string nombrecategoria = ServValidac.PedirStringNoVac("Ingrese nombre de la categoria a la que pertenece");

                Repuesto repuesto = new Repuesto(codigo, nombre, precio, stock, codigocategoria);
                local.AgregarRepuesto(repuesto);
                Console.WriteLine("repuesto ingresado con exito");
            }
            catch (CodigoExistenteException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (RepuestoExistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void EliminarRepuesto(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(local.ListarRepuestos());
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto a eliminar");
                local.QuitarRepuesto(codigo);
                Console.WriteLine("repuesto eliminado con exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ModificarRepuesto(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(local.ListarRepuestos());
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto a modificar");
                string nombre = ServValidac.PedirStringNoVac("Ingrese nuevo nombre");
                double precio = ServValidac.PedirDouble("Ingrese nuevo precio");
                int stock = ServValidac.PedirInt("Ingrese nuevo stock");
                int codigocategoria = ServValidac.PedirInt("Ingrese codigo de la categoria a la que pertenece");
                //string nombrecategoria = ServValidac.PedirStringNoVac("Ingrese nombre de la categoria a la que pertenece");
                
                Repuesto repuesto = new Repuesto(codigo, nombre, precio, stock, codigocategoria);
                local.ModificarRepuesto(repuesto);
                Console.WriteLine("El repuesto fue modificado y quedo de esta manera: \n" + local.ListarRepuestos());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void InsertarStock(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(local.ListarRepuestos());
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto a acumular stock");
                int stock = ServValidac.PedirInt("Ingrese stock de repuesto a acumular");
                local.AgregarStock(codigo, stock);
                Console.WriteLine("repuesto con nuevo stock");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void EliminarStock(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(local.ListarRepuestos());
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto a restar stock");
                int stock = ServValidac.PedirInt("Ingrese stock de repuesto a restar");
                local.QuitarStock(codigo, stock);
                Console.WriteLine("repuesto con nuevo stock");
            }
            catch (StockNegativoException sn)
            {
                Console.WriteLine(sn.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ModificarPrecio(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(local.ListarRepuestos());
                int codigo = ServValidac.PedirInt("Ingrese codigo de repuesto a modificar su precio");
                double precio = ServValidac.PedirInt("Ingrese nuevo precio del repuesto a modificar");
                local.ModificarPrecio(codigo, precio);
                Console.WriteLine("repuesto con nuevo stock");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListarPorCategoria(VentaRepuesto local)
        {
            try
            {
                Console.WriteLine(CategoriaHelper.ListarCategorias());
                int categoria = ServValidac.PedirInt("ingrese codigo de categoría a listar");
                Console.WriteLine(local.ListaPorCategoria(categoria));
                
            }
            catch (CategoriaExistenteException ce)
            {
                Console.WriteLine(ce.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente.");
            }
        }
    }
}
