using System;

namespace SISTEMA_GESTION_DE_HOTEL
{
    internal class EjecutarHuesped
    {
        private Usuario huesped;

        public EjecutarHuesped(Usuario usuario)
        {
            huesped = usuario;
        }

        public void VerReservas()
        {
            Console.WriteLine("\n=== TUS RESERVAS ===");
            Console.WriteLine($"Nombre: {huesped.NombreCompleto}");
            Console.WriteLine("Habitación: 204");
            Console.WriteLine("Tipo: Doble");
            Console.WriteLine("Check-in: 28/07/2025");
            Console.WriteLine("Check-out: 01/08/2025");
            Console.WriteLine("Estado: Confirmada");
        }

        public void VerServicios()
        {
            Console.WriteLine("\n=== SERVICIOS DEL HOTEL ===");
            Console.WriteLine("- Restaurante abierto de 6:00 AM a 10:00 PM");
            Console.WriteLine("- Piscina disponible de 8:00 AM a 8:00 PM");
            Console.WriteLine("- Servicio de lavandería");
            Console.WriteLine("- Wi-Fi gratuito en todo el hotel");
            Console.WriteLine("- Parqueo privado");
        }

        public void SolicitarServicioHabitacion()
        {
            Console.WriteLine("\n=== SOLICITAR SERVICIO A LA HABITACIÓN ===");
            Console.Write("Escriba el servicio que desea solicitar (ej. comida, toallas, limpieza): ");
            string servicio = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(servicio))
            {
                Console.WriteLine($" Solicitud enviada: '{servicio}'. Nuestro personal lo atenderá pronto.");
            }
            else
            {
                Console.WriteLine(" No se ingresó ningún servicio.");
            }
        }

        public void VerEstadoCuenta()
        {
            Console.WriteLine("\n=== ESTADO DE CUENTA ===");
            Console.WriteLine($"Huésped: {huesped.NombreCompleto}");
            Console.WriteLine("Habitación: 204");
            Console.WriteLine("Noches: 4");
            Console.WriteLine("Precio por noche: L. 1,400");
            Console.WriteLine("Total: L. 5,600");
            Console.WriteLine("Estado de pago: PAGADO");
        }
    }
}
