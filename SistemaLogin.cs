using System;
using System.Collections.Generic;
using System.Linq;

namespace SISTEMA_GESTION_DE_HOTEL
{
    public class SistemaLogin
    {
        private List<Usuario> usuarios;
        private Usuario usuarioActual; // Variable para almacenar el usuario logueado

        public SistemaLogin(List<Usuario> listaUsuarios)
        {
            usuarios = listaUsuarios;
        }

        public SistemaLogin()
        {
            InicializarUsuarios();
        }

        // Inicializar usuarios de demostración, no se dejo visible la contraseña
        private void InicializarUsuarios()
        {
            usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "admin",
                    Contraseña = "admin2025",
                    NombreCompleto = "Marlon Varela",
                    Tipo = TipoUsuario.Administrador
                },
                new Usuario
                {
                    Id = 2,
                    NombreUsuario = "recepcion",
                    Contraseña = "recep2025",
                    NombreCompleto = "Katerine Ramirez",
                    Tipo = TipoUsuario.Recepcionista
                },
                new Usuario
                {
                    Id = 3,
                    NombreUsuario = "huesped1",
                    Contraseña = "sindy2025",
                    NombreCompleto = "Sindy Romero",
                    Tipo = TipoUsuario.Huesped
                }
            };
        }

        // Mostrar usuarios de demostración
        public void MostrarUsuariosDemo()
        {
            Encabezado.Demostracion();

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Tipo: {usuario.Tipo}");
                Console.WriteLine($"Usuario: {usuario.NombreUsuario}");
                Console.WriteLine($"Contraseña: {usuario.Contraseña}");
                Console.WriteLine($"Nombre: {usuario.NombreCompleto}");
                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar al login...");
            Console.ReadKey();
        }

        // Método principal para iniciar sesión
        public bool IniciarSesion()
        {
            int intentos = 0;
            const int maxIntentos = 3;

            while (intentos < maxIntentos)
            {
                Console.Clear();
                Encabezado.MostrarEncabezadoLogin();

                Console.Write("Usuario: ");
                string nombreUsuario = Console.ReadLine();

                Console.Write("Contraseña: ");
                string contraseña = LeerContraseñaOculta();

                // Buscar usuario
                Usuario usuario = usuarios.FirstOrDefault(u =>
                    u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                    u.Contraseña == contraseña);

                if (usuario != null)
                {
                    usuarioActual = usuario; // Se guardara datos de Usuario
                    Console.WriteLine($"\n Bienvenido, {usuario.NombreCompleto}!");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    intentos++;
                    Console.WriteLine($"\n✗ Credenciales incorrectas. Intento {intentos}/{maxIntentos}");

                    if (intentos < maxIntentos)
                    {
                        Console.WriteLine("Presiona cualquier tecla para intentar nuevamente...");
                        Console.ReadKey();
                    }
                }
            }

            Console.WriteLine($"\n✗ Máximo número de intentos alcanzado ({maxIntentos}).");
            Console.WriteLine("El sistema se cerrará por seguridad.");
            return false;
        }

        // Método para obtener el usuario actual (el que se logueó exitosamente)
        public Usuario ObtenerUsuarioActual()
        {
            return usuarioActual;
        }

        // Leer contraseña con asteriscos
        private string LeerContraseñaOculta()
        {
            string contraseña = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Backspace && contraseña.Length > 0)
                {
                    contraseña = contraseña.Substring(0, contraseña.Length - 1);
                    Console.Write("\b \b");
                }
                else if (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Backspace)
                {
                    contraseña += tecla.KeyChar;
                    Console.Write("*");
                }
            }
            while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return contraseña;
        }

        // Método para cerrar sesión
        public void CerrarSesion()
        {
            usuarioActual = null;
        }
    }
}
