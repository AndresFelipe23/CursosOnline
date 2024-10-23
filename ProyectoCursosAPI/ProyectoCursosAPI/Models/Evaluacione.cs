using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Evaluacione
{
    public int EvaluacionId { get; set; }

    public int CursoId { get; set; }

    public int? EtapaId { get; set; }

    public string EvalTitulo { get; set; } = null!;

    public string? EvalDescripcion { get; set; }

    public DateTime EvalFechaCreacion { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual Etapa? Etapa { get; set; }
}
