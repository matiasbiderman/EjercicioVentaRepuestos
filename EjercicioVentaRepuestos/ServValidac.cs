using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVentaRepuestos
{
    public static class ServValidac
    {
        public static int PedirInt(string mensaje)
        {
            int valor;

            Console.WriteLine(mensaje);
            do
            {
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    valor = -1;
                }
                if(valor <= 0)
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (valor <= 0 );

            return valor;
        }
        public static double PedirDouble(string mensaje)
        {
            double valor;
            Console.WriteLine(mensaje);
            do
            {
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    valor = -1;
                }
                if (valor <= 0)
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (valor <= 0);

            return valor;
        }
        public static string PedirStringNoVac(string mensaje)
        {
            string retorno;
            Console.WriteLine(mensaje);
            do
            {
                retorno = Console.ReadLine().ToUpper().Trim();
                if (retorno == "")
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
            } while (retorno == "");

            return retorno;
        }
    }
}
