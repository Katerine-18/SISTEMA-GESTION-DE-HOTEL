using System;
using System.Collections.Generic;
using System.Linq;

namespace SISTEMA_GESTION_DE_HOTEL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión Hotelera";

            // Crear lista de usuarios con los datos solicitados
            List<Usuario> listaUsuarios = new List<Usuario>
            {
                new Usuario("admin", "admin2025", TipoUsuario.Administrador, "Marlon Varela"),
                new Usuario("recpcion", "recep2025", TipoUsuario.Recepcionista, "Katerine Ramirez"),
                new Usuario("huesped1", "sindy2025", TipoUsuario.Huesped, "Sindy Romero")
            };

            // Crear sistema de login con la lista de usuarios
            SistemaLogin sistema = new SistemaLogin(listaUsuarios);

            // Mostrar usuarios de demostración para Iniciar Sesión
            sistema.MostrarUsuariosDemo();

            // Hacer inicio de sesión
            if (sistema.IniciarSesion())
            {
                // Si el login es exitoso, mostrar el menú principal
                Usuario usuarioLogueado = sistema.ObtenerUsuarioActual();
                MenuPrincipal menu = new MenuPrincipal(usuarioLogueado, listaUsuarios);
                menu.MostrarMenuPrincipal();
            }

            Console.WriteLine("\n¡Gracias por usar nuestro sistema!");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}


