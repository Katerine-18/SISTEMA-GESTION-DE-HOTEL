using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionHotel
{
    // Clase cliente
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string Habitacion { get; set; }
        public bool CheckInRealizado { get; set; } = false;
    }

    // Clase para manejar las opciones del recepcionista
    public class RecepcionistaManager
    {
        private static List<Cliente> listaClientes = new List<Cliente>();

        // Métodos de instancia (sin static)
        public static void RegistrarCliente()
        {
            Console.WriteLine("===== REGISTRAR NUEVO CLIENTE =====");
            Cliente nuevo = new Cliente();
            Console.Write("Nombre del cliente: ");
            nuevo.Nombre = Console.ReadLine();
            Console.Write("Número de identidad: ");
            nuevo.Identidad = Console.ReadLine();
            Console.Write("Número de habitación: ");
            nuevo.Habitacion = Console.ReadLine();
            listaClientes.Add(nuevo);
            Console.WriteLine("Cliente registrado exitosamente.");
        }

        public static void VerReservas()
        {
            Console.WriteLine("===== LISTA DE RESERVAS =====");
            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Identidad: {cliente.Identidad}");
                Console.WriteLine($"Habitación: {cliente.Habitacion}");
                Console.WriteLine($"Check-in: {(cliente.CheckInRealizado ? "Realizado" : "Pendiente")}");
                Console.WriteLine("----------------------------------");
            }
        }

        public static void HacerCheckIn()
        {
            Console.WriteLine("===== CHECK-IN CLIENTE =====");
            Console.Write("Ingrese el número de identidad del cliente: ");
            string identidad = Console.ReadLine();
            Cliente cliente = listaClientes.Find(c => c.Identidad == identidad);
            if (cliente != null)
            {
                if (cliente.CheckInRealizado)
                {
                    Console.WriteLine("Este cliente ya realizó el check-in.");
                }
                else
                {
                    cliente.CheckInRealizado = true;
                    Console.WriteLine("Check-in realizado correctamente.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public static void HacerCheckOut()
        {
            Console.WriteLine("===== CHECK-OUT CLIENTE =====");
            Console.Write("Ingrese el número de identidad del cliente: ");
            string identidad = Console.ReadLine();
            Cliente cliente = listaClientes.Find(c => c.Identidad == identidad);
            if (cliente != null)
            {
                listaClientes.Remove(cliente);
                Console.WriteLine("Check-out realizado. Cliente eliminado de la lista.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }



}
