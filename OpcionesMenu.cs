using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_GESTION_DE_HOTEL
{
    internal class OpcionesMenu
    {
        private bool ProcesarOpcionMenu()
        {
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "0":
                    Console.WriteLine("\n¡Hasta luego! Sesión cerrada exitosamente.");
                    Console.WriteLine("Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    return false;

                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    Console.WriteLine($"\nHas seleccionado la opción {opcion}");
                    Console.WriteLine("Esta funcionalidad se implementará próximamente...");
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("\nOpción no válida. Intenta nuevamente.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }
    }
}
