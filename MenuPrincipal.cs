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
        private AdministradorController adminController;

        public MenuPrincipal(Usuario usuario, List<Usuario> listaUsuarios)
        {
            usuarioActual = usuario;
            adminController = new AdministradorController(listaUsuarios);
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
                    adminController.GestionarUsuarios();
                    break;
                case 2:
                    adminController.ReportesSistema();
                    break;
                case 3:
                    adminController.ConfiguracionHotel();
                    break;
                case 4:
                    adminController.GestionarHabitaciones();
                    break;
                case 5:
                    adminController.GestionarReservas();
                    break;
                case 6:
                    adminController.EstadosFinancieros();
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

    public class AdministradorController
    {
        private List<Usuario> usuarios;
        private List<Habitacion> habitaciones = new List<Habitacion>();
        private List<Reserva> reservas = new List<Reserva>();
        private readonly Dictionary<string, decimal> preciosHabitacion = new Dictionary<string, decimal>
        {
            { "Sencilla", 1500L },
            { "Doble", 2000L },
            { "Suite", 4000L }
        };

        private readonly decimal costoReserva = 100L;



        // Variables privadas para simular configuraciones:
        private string nombreHotel = "HOTEL JARDIN ESCONDIDO";
        private int maxHabitaciones = 100;
        private string horarioCheckIn = "14:00";
        private string horarioCheckOut = "12:00";

        public AdministradorController(List<Usuario> listaUsuarios)
        {
            usuarios = listaUsuarios;
        }

        public void GestionarUsuarios()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
                Console.WriteLine("1. Ver Usuarios");
                Console.WriteLine("2. Agregar Usuario");
                Console.WriteLine("3. Editar Usuario");
                Console.WriteLine("4. Eliminar Usuario");
                Console.WriteLine("0. Volver al Menú");
                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerUsuarios();
                        break;
                    case "2":
                        AgregarUsuario();
                        break;
                    case "3":
                        EditarUsuario();
                        break;
                    case "4":
                        EliminarUsuario();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ReportesSistema()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== REPORTES DEL SISTEMA ===");
                Console.WriteLine("1. Ver Usuarios Activos");
                Console.WriteLine("2. Cantidad de Usuarios por Rol");
                Console.WriteLine("0. Volver al Menú");
                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarReporteUsuariosActivos();
                        break;
                    case "2":
                        MostrarCantidadPorTipoUsuario();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ConfiguracionHotel()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== CONFIGURACIÓN DEL HOTEL ===");
                Console.WriteLine("1. Cambiar Nombre del Hotel");
                Console.WriteLine("2. Ajustar Número Máximo de Habitaciones");
                Console.WriteLine("3. Configurar Horario de Check-in");
                Console.WriteLine("4. Configurar Horario de Check-out");
                Console.WriteLine("0. Volver al Menú Anterior");
                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CambiarNombreHotel();
                        break;
                    case "2":
                        AjustarMaxHabitaciones();
                        break;
                    case "3":
                        ConfigurarHorarioCheckIn();
                        break;
                    case "4":
                        ConfigurarHorarioCheckOut();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void GestionarHabitaciones()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE HABITACIONES ===");
                Console.WriteLine("1. Ver Habitaciones");
                Console.WriteLine("2. Agregar Habitación");
                Console.WriteLine("3. Cambiar Estado de Habitación");
                Console.WriteLine("0. Volver al Menú");

                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerHabitaciones();
                        break;
                    case "2":
                        AgregarHabitacion();
                        break;
                    case "3":
                        CambiarEstadoHabitacion();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void GestionarReservas()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE RESERVAS ===");
                Console.WriteLine("1. Ver Reservas");
                Console.WriteLine("2. Crear Nueva Reserva");
                Console.WriteLine("3. Cancelar Reserva");
                Console.WriteLine("0. Volver al Menú");

                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerReservas();
                        break;
                    case "2":
                        CrearReserva();
                        break;
                    case "3":
                        CancelarReserva();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void EstadosFinancieros()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== ESTADOS FINANCIEROS ===");
                Console.WriteLine("1. Ver Ingresos por Reservas");
                Console.WriteLine("2. Ver Ocupación Actual de Habitaciones");
                Console.WriteLine("3. Ver Total Ingresos Estimados");
                Console.WriteLine("0. Volver al Menú");
                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerIngresosPorReservas();
                        break;
                    case "2":
                        VerOcupacionHabitaciones();
                        break;
                    case "3":
                        VerTotalIngresos();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void VerIngresosPorReservas()
        {
            Console.Clear();
            Console.WriteLine("=== INGRESOS POR RESERVAS ===");

            decimal precioPorReserva = costoReserva;
            int cantidadReservas = reservas.Count;
            decimal total = cantidadReservas * precioPorReserva;

            Console.WriteLine($"Reservas realizadas: {cantidadReservas}");
            Console.WriteLine($"Ingreso estimado por reservas: ${total}");

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerOcupacionHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("=== OCUPACIÓN DE HABITACIONES ===");

            int totalHabitaciones = habitaciones.Count;
            int ocupadas = habitaciones.Count(h => !h.Disponible);
            int disponibles = habitaciones.Count(h => h.Disponible);

            Console.WriteLine($"Total de habitaciones: {totalHabitaciones}");
            Console.WriteLine($"Habitaciones ocupadas: {ocupadas}");
            Console.WriteLine($"Habitaciones disponibles: {disponibles}");

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerTotalIngresos()
        {
            Console.Clear();
            Console.WriteLine("=== TOTAL DE INGRESOS ESTIMADOS ===");

            decimal ingresoTotal = 0m;

            foreach (var reserva in reservas)
            {
                var habitacion = habitaciones.FirstOrDefault(h => h.Numero == reserva.NumeroHabitacion);
                if (habitacion != null && preciosHabitacion.ContainsKey(habitacion.Tipo))
                {
                    ingresoTotal += preciosHabitacion[habitacion.Tipo] + costoReserva;
                }
            }

            Console.WriteLine($"Total ingresos estimados: ${ingresoTotal}");

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }


        private void CrearReserva()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR NUEVA RESERVA ===");

            Console.Write("Nombre del cliente: ");
            string cliente = Console.ReadLine();

            Console.Write("Número de habitación: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                var habitacion = habitaciones.FirstOrDefault(h => h.Numero == numero);

                if (habitacion == null)
                {
                    Console.WriteLine("❌ La habitación no existe.");
                }
                else if (!habitacion.Disponible)
                {
                    Console.WriteLine("❌ La habitación está ocupada.");
                }
                else
                {
                    reservas.Add(new Reserva(cliente, numero, DateTime.Now));
                    habitacion.Disponible = false;
                    Console.WriteLine("✅ Reserva creada exitosamente.");
                }
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerReservas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE RESERVAS ===\n");

            if (reservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
            }
            else
            {
                foreach (var r in reservas)
                {
                    Console.WriteLine($"📌 Cliente: {r.Cliente} | Habitación: {r.NumeroHabitacion} | Fecha: {r.Fecha:g}");
                }
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void CancelarReserva()
        {
            Console.Clear();
            Console.WriteLine("=== CANCELAR RESERVA ===");

            Console.Write("Ingrese nombre del cliente: ");
            string cliente = Console.ReadLine();

            Console.Write("Número de habitación: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                var reserva = reservas.FirstOrDefault(r => r.Cliente.Equals(cliente, StringComparison.OrdinalIgnoreCase) && r.NumeroHabitacion == numero);
                if (reserva != null)
                {
                    reservas.Remove(reserva);
                    var habitacion = habitaciones.FirstOrDefault(h => h.Numero == numero);
                    if (habitacion != null)
                    {
                        habitacion.Disponible = true;
                    }

                    Console.WriteLine("✅ Reserva cancelada exitosamente.");
                }
                else
                {
                    Console.WriteLine("❌ Reserva no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }





        private void VerHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE HABITACIONES ===\n");

            if (habitaciones.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas.");
            }
            else
            {
                foreach (var hab in habitaciones)
                {
                    Console.WriteLine($"🛏 Habitación {hab.Numero} | Tipo: {hab.Tipo} | Estado: {(hab.Disponible ? "Disponible" : "Ocupada")}");
                }
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void AgregarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR HABITACIÓN ===");

            Console.Write("Número de habitación: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                if (habitaciones.Any(h => h.Numero == numero))
                {
                    Console.WriteLine("❌ Ya existe una habitación con ese número.");
                }
                else
                {
                    Console.Write("Tipo de habitación (Sencilla, Doble, Suite): ");
                    string tipo = Console.ReadLine();
                    habitaciones.Add(new Habitacion(numero, tipo));
                    Console.WriteLine("✅ Habitación agregada exitosamente.");
                }
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void CambiarEstadoHabitacion()
        {
            Console.Clear();
            Console.WriteLine("=== CAMBIAR ESTADO DE HABITACIÓN ===");

            Console.Write("Número de habitación: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                var habitacion = habitaciones.FirstOrDefault(h => h.Numero == numero);
                if (habitacion != null)
                {
                    habitacion.Disponible = !habitacion.Disponible;
                    Console.WriteLine($"✅ Estado cambiado a: {(habitacion.Disponible ? "Disponible" : "Ocupada")}");
                }
                else
                {
                    Console.WriteLine("❌ Habitación no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("❌ Número inválido.");
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }


        private void CambiarNombreHotel()
        {
            Console.Clear();
            Console.WriteLine($"Nombre actual del hotel: {nombreHotel}");
            Console.Write("Ingrese nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                nombreHotel = nuevoNombre.Trim();
                Console.WriteLine($"✅ Nombre del hotel actualizado a: {nombreHotel}");
            }
            else
            {
                Console.WriteLine("❌ Nombre no válido, no se realizaron cambios.");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void AjustarMaxHabitaciones()
        {
            Console.Clear();
            Console.WriteLine($"Número máximo actual de habitaciones: {maxHabitaciones}");
            Console.Write("Ingrese nuevo número máximo: ");
            if (int.TryParse(Console.ReadLine(), out int nuevoMax) && nuevoMax > 0)
            {
                maxHabitaciones = nuevoMax;
                Console.WriteLine($"✅ Número máximo de habitaciones actualizado a: {maxHabitaciones}");
            }
            else
            {
                Console.WriteLine("❌ Valor inválido, no se realizaron cambios.");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void ConfigurarHorarioCheckIn()
        {
            Console.Clear();
            Console.WriteLine($"Horario de check-in actual: {horarioCheckIn}");
            Console.Write("Ingrese nuevo horario de check-in (HH:mm): ");
            string nuevoHorario = Console.ReadLine();

            if (TimeSpan.TryParse(nuevoHorario, out _))
            {
                horarioCheckIn = nuevoHorario;
                Console.WriteLine($"✅ Horario de check-in actualizado a: {horarioCheckIn}");
            }
            else
            {
                Console.WriteLine("❌ Formato inválido, no se realizaron cambios.");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void ConfigurarHorarioCheckOut()
        {
            Console.Clear();
            Console.WriteLine($"Horario de check-out actual: {horarioCheckOut}");
            Console.Write("Ingrese nuevo horario de check-out (HH:mm): ");
            string nuevoHorario = Console.ReadLine();

            if (TimeSpan.TryParse(nuevoHorario, out _))
            {
                horarioCheckOut = nuevoHorario;
                Console.WriteLine($"✅ Horario de check-out actualizado a: {horarioCheckOut}");
            }
            else
            {
                Console.WriteLine("❌ Formato inválido, no se realizaron cambios.");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarReporteUsuariosActivos()
        {
            Console.Clear();
            Console.WriteLine("=== USUARIOS ACTIVOS ===\n");

            var activos = usuarios.Where(u => u.Activo).ToList();

            if (activos.Count == 0)
            {
                Console.WriteLine("No hay usuarios activos actualmente.");
            }
            else
            {
                foreach (var u in activos)
                {
                    Console.WriteLine($"👤 {u.NombreCompleto} | Usuario: {u.NombreUsuario} | Rol: {u.Tipo}");
                }
            }

            Console.WriteLine("\nPresiona una tecla para volver...");
            Console.ReadKey();
        }

        private void MostrarCantidadPorTipoUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== CANTIDAD DE USUARIOS POR ROL ===\n");

            var conteo = usuarios
                .GroupBy(u => u.Tipo)
                .Select(g => new { Tipo = g.Key, Cantidad = g.Count() });

            foreach (var grupo in conteo)
            {
                Console.WriteLine($"📊 {grupo.Tipo}: {grupo.Cantidad} usuarios");
            }

            Console.WriteLine("\nPresiona una tecla para volver...");
            Console.ReadKey();
        }

        private void VerUsuarios()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE USUARIOS ===\n");

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"👤 {usuario.NombreCompleto} | Usuario: {usuario.NombreUsuario} | Rol: {usuario.Tipo} | Estado: {(usuario.Activo ? "Activo" : "Inactivo")}");
            }

            Console.WriteLine("\nPresiona una tecla para volver...");
            Console.ReadKey();
        }

        private void AgregarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR NUEVO USUARIO ===");

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Nombre de usuario: ");
            string username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            Console.WriteLine("Tipo de usuario: 0=Administrador, 1=Recepcionista, 2=Huésped");
            Console.Write("Selecciona tipo: ");
            int tipo = int.Parse(Console.ReadLine());

            usuarios.Add(new Usuario(username, pass, (TipoUsuario)tipo, nombre));
            Console.WriteLine("\n✅ Usuario agregado exitosamente.");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void EditarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR USUARIO ===");

            Console.Write("Ingrese nombre de usuario a editar: ");
            string username = Console.ReadLine();

            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == username);
            if (usuario == null)
            {
                Console.WriteLine("❌ Usuario no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Editando a: {usuario.NombreCompleto} ({usuario.Tipo})");

            Console.Write("Nuevo nombre completo (enter para mantener): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                usuario.NombreCompleto = nuevoNombre;

            Console.Write("Nueva contraseña (enter para mantener): ");
            string nuevaClave = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaClave))
                usuario.Contraseña = nuevaClave;

            Console.WriteLine("Nuevo tipo de usuario (0=Administrador, 1=Recepcionista, 2=Huésped, enter para mantener): ");
            string nuevoTipo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTipo))
                usuario.Tipo = (TipoUsuario)int.Parse(nuevoTipo);

            Console.WriteLine("✅ Usuario actualizado. Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR USUARIO ===");

            Console.Write("Ingrese nombre de usuario a eliminar: ");
            string username = Console.ReadLine();

            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == username);
            if (usuario == null)
            {
                Console.WriteLine("❌ Usuario no encontrado.");
                Console.ReadKey();
                return;
            }

            usuario.Activo = false;
            Console.WriteLine($"✅ Usuario {usuario.NombreUsuario} desactivado.");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
