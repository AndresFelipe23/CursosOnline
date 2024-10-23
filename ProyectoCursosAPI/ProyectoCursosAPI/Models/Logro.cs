using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Logro
{
    public int LogroId { get; set; }

    public string LogroNombre { get; set; } = null!;

    public string? LogroDescripcion { get; set; }

    public int PuntosRequeridos { get; set; }

    public string? LogroImagenUrl { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<UsuarioLogro> UsuarioLogros { get; set; } = new List<UsuarioLogro>();
}
