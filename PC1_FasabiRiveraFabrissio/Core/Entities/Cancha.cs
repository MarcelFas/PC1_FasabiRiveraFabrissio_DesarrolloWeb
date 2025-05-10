using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Entities;

public partial class Cancha
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
