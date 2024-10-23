using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Inscripcione
{
    public int InscripcionId { get; set; }

    public string UsuarioUid { get; set; } = null!;

    public int CursoId { get; set; }

    public DateTime InsFechaInscripcion { get; set; }

    public string InsEstado { get; set; } = null!;

    public double? InsProgresoTotal { get; set; }

    public bool InsCertificadoOtorgado { get; set; }

    public virtual Curso Curso { get; set; } = null!;
}
