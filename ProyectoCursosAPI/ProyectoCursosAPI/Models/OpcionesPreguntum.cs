using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class OpcionesPreguntum
{
    public int OpcionId { get; set; }

    public int PreguntaId { get; set; }

    public string OpcionTexto { get; set; } = null!;

    public bool EsCorrecta { get; set; }

    public virtual PreguntasLeccion Pregunta { get; set; } = null!;

    public virtual ICollection<RespuestasUsuario> RespuestasUsuarios { get; set; } = new List<RespuestasUsuario>();
}
