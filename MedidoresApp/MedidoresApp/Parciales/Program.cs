using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresApp
{
    public partial class Program
    {
         static void Fecha()
        {
            string Fecha = "Alguna fecha cualquiera";
            int FechaError = 0;
            DateTime FechaValida = new DateTime();

            try
            {
                FechaValida = DateTime.Parse(Fecha);
                if (FechaValida.ToString("yyyy-MM-dd-HH-mm-ss") == Fecha)
                    FechaError = 0;
                else
                {
                    FechaValida = new DateTime();
                    FechaError = 2;
                }
            }
            catch(Exception ex)
            {
                FechaError = 2;
            }
        }

          static bool menu()
        {
            bool flag = true;
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("(1) Ingresar Mensajes ");
            Console.WriteLine("(2) Mostrar Mensajes");
            Console.WriteLine("(0) Salir");
            string respuesta = Console.ReadLine().Trim();
            switch (respuesta)
            {
                case "1":
                    IngresarMensajes();
                    break;
                case "2":
                    MostrarMensajes();
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

         static void Medidor()
        {
            int nroMedidor = 0;

            do
            {
                try
                {
                    Console.WriteLine("ingrese numero de medidor");
                    nroMedidor = Int32.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ingrese numero de medidor");

                }
            } while (nroMedidor >= 1 && nroMedidor <= 3);




        }
        static void tipo()
        {
            string tipo="";

            do
            {
                try
                {
                    Console.WriteLine("ingrese tipo");
                    tipo = Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ingrese tipo");
                }
            } while (tipo != "trafico" || tipo != "consumo");
        }
    }
}
