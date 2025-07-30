using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_GESTION_DE_HOTEL
{
    internal class MenuPrincipal
    {
        private Usuario usuarioActual;

        public MenuPrincipal(Usuario usuario)
        {
            usuarioActual = usuario;
        }

        public void MostrarMenuPrincipal()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Encabezado.MostrarEncabezado();
                Console.WriteLine($"Usuario: {usuarioActual.NombreCompleto} ({usuarioActual.Tipo})\n");

                switch (usuarioActual.Tipo)
                {
                    case TipoUsuario.Administrador:
                        continuar = MostrarMenuAdministrador();
                        break;
                    case TipoUsuario.Recepcionista:
                        continuar = MostrarMenuRecepcionista();
                        break;
                    case TipoUsuario.Huesped:
                        continuar = MostrarMenuHuesped();
                        break;
                }
            }
        }

        private bool MostrarMenuAdministrador()
        {
            Console.WriteLine("=== MENÚ ADMINISTRADOR ===");
            Console.WriteLine("1. Gestión de Usuarios");
            Console.WriteLine("2. Reportes del Sistema");
            Console.WriteLine("3. Configuración del Hotel");
            Console.WriteLine("4. Gestión de Habitaciones");
            Console.WriteLine("5. Gestión de Reservas");
            Console.WriteLine("6. Estados Financieros");
            Console.WriteLine("0. Cerrar Sesión");
            Console.Write("\nSelecciona una opción: ");
            return ProcesarOpcionMenu();
        }

        private bool MostrarMenuRecepcionista()
        {
            Console.WriteLine("=== MENÚ RECEPCIONISTA ===");
            Console.WriteLine("1. Check-in de Huéspedes");
            Console.WriteLine("2. Check-out de Huéspedes");
            Console.WriteLine("3. Consultar Reservas");
            Console.WriteLine("4. Gestión de Habitaciones");
            Console.WriteLine("5. Facturación");
            Console.WriteLine("0. Cerrar Sesión");
            Console.Write("\nSelecciona una opción: ");
            return ProcesarOpcionMenu();
        }

        private bool MostrarMenuHuesped()
        {
            Console.WriteLine("=== MENÚ HUÉSPED ===");
            Console.WriteLine("1. Ver mis Reservas");
            Console.WriteLine("2. Servicios del Hotel");
            Console.WriteLine("3. Solicitar Servicio a Habitación");
            Console.WriteLine("4. Estado de Cuenta");
            Console.WriteLine("0. Cerrar Sesión");
            Console.Write("\nSelecciona una opción: ");
            return ProcesarOpcionMenu();
        }

        private bool ProcesarOpcionMenu()
        {
            try
            {
                string input = Console.ReadLine();
                int opcion = Convert.ToInt32(input);

                if (opcion == 0)
                {
                    Console.WriteLine("\nCerrando sesión...");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    return false;
                }

                EjecutarOpcion(opcion);

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: Opción no válida. {ex.Message}");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                return true;
            }
        }

        private void EjecutarOpcion(int opcion)
        {
            switch (usuarioActual.Tipo)
            {
                case TipoUsuario.Administrador:
                    EjecutarOpcionAdministrador(opcion);
                    break;
                case TipoUsuario.Recepcionista:
                    EjecutarOpcionRecepcionista(opcion);
                    break;
                case TipoUsuario.Huesped:
                    EjecutarOpcionHuesped(opcion);
                    break;
            }
        }

        private void EjecutarOpcionAdministrador(int opcion)
        {
            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    Console.WriteLine("En desarrollo");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private void EjecutarOpcionRecepcionista(int opcion)
        {
            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("En desarrollo");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private void EjecutarOpcionHuesped(int opcion)
        {
            EjecutarHuesped acciones = new EjecutarHuesped(usuarioActual);

            switch (opcion)
            {
                case 1:
                    acciones.VerReservas();
                    break;
                case 2:
                    acciones.VerServicios();
                    break;
                case 3:
                    acciones.SolicitarServicioHabitacion();
                    break;
                case 4:
                    acciones.VerEstadoCuenta();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}
