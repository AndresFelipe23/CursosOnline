using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class RespuestasUsuario
{
    public int RespuestaId { get; set; }

    public string UsuarioUid { get; set; } = null!;

    public int PreguntaId { get; set; }

    public int OpcionId { get; set; }

    public DateTime FechaRespuesta { get; set; }

    public virtual OpcionesPreguntum Opcion { get; set; } = null!;

    public virtual PreguntasLeccion Pregunta { get; set; } = null!;
}
