using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_GESTION_DE_HOTEL
{
    internal class Reserva
    {
        public string Cliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime Fecha { get; set; }

        public Reserva(string cliente, int numeroHabitacion, DateTime fecha)
        {
            Cliente = cliente;
            NumeroHabitacion = numeroHabitacion;
            Fecha = fecha;
        }
    }
}
