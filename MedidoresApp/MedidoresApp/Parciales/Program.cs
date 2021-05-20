using MedidoresApp.ValidacionesUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresApp
{
    public partial class Program
    {

        public static void IngresarMensaje()
        {
            string mensaje;
            DateTime fechaActual = DateTime.Now;
            Validaciones v = new Validaciones();
            do
            {
                do
                {
                    mensaje = Console.ReadLine().Trim();
                } while (mensaje == string.Empty);

            } while (v.mensajeCorrecto(mensaje));

            Console.WriteLine(fechaActual.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");

            mensaje = Console.ReadLine().Trim();

            v.lecturaCorrecta(mensaje);

            Console.WriteLine(mensaje);

        }

        static bool menu()
        {
            bool flag = true;
            Console.WriteLine("Seleccione el tipo de medidor");
            Console.WriteLine("(1) Trafico");
            Console.WriteLine("(2) Consumo ");
            Console.WriteLine("(0) Salir");
            string respuesta = Console.ReadLine().Trim();
            switch (respuesta)
            {
                case "1":
                    IngresarMensaje();
                    break;
                case "2":
                    IngresarMensaje();
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("La opcion no es valida");
                    break;

            }
            return flag;
        }

    }
}
