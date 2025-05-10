using System;
using System.Collections.Generic;

namespace Core.Entities
{
public class Reserva

{
    public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string? ClienteNombre { get; set; }
        public int? CanchaId { get; set; }
        public virtual Cancha? Cancha { get; set; }
    }
}
