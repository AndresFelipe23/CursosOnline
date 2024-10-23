using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class PreguntasLeccion
{
    public int PreguntaId { get; set; }

    public int LeccionId { get; set; }

    public string PreguntaTexto { get; set; } = null!;

    public string TipoPregunta { get; set; } = null!;

    public virtual Leccione Leccion { get; set; } = null!;

    public virtual ICollection<OpcionesPreguntum> OpcionesPregunta { get; set; } = new List<OpcionesPreguntum>();

    public virtual ICollection<RespuestasUsuario> RespuestasUsuarios { get; set; } = new List<RespuestasUsuario>();
}
