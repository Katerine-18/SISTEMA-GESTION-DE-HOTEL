using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_GESTION_DE_HOTEL
{
    internal class Habitacion
    {
        public int Numero { get; set; }
        public string Tipo { get; set; } // Ej: Sencilla, Doble, Suite
        public bool Disponible { get; set; }

        public Habitacion(int numero, string tipo)
        {
            Numero = numero;
            Tipo = tipo;
            Disponible = true;
        }
    }
}
