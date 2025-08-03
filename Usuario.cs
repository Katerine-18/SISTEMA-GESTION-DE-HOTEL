using System;

namespace SISTEMA_GESTION_DE_HOTEL
{
    // Enumeración para los tipos de usuario
    public enum TipoUsuario
    {
        Administrador,
        Recepcionista,
        Huesped
    }

    // Clase Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // Constructor
        public Usuario()
        {
            FechaCreacion = DateTime.Now;
            Activo = true;
        }

        // Constructor con parámetros
        public Usuario(string nombreUsuario, string contraseña, TipoUsuario tipo, string nombreCompleto)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Tipo = tipo;
            NombreCompleto = nombreCompleto;
            FechaCreacion = DateTime.Now;
            Activo = true;
        }

        // Método para mostrar información del usuario
        public override string ToString()
        {
            return $"{NombreCompleto} ({Tipo})";
        }

        // Método para validar credenciales
        public bool ValidarCredenciales(string usuario, string contraseña)
        {
            return NombreUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase) &&
                   Contraseña == contraseña &&
                   Activo;
        }
    }
}