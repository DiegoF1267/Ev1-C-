﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresApp
{
    public partial class Program
    {
       

        static bool menu()
        {
            bool flag = true;
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("(1) Ingresar  ");
            Console.WriteLine("(2) Mostrar ");
            Console.WriteLine("(0) Salir");
            string respuesta = Console.ReadLine().Trim();
            switch (respuesta)
            {
                case "1":
                    ;
                    break;
                case "2":
                    ;
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
