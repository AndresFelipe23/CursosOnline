using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Leccione
{
    public int LeccionId { get; set; }

    public string LecTitulo { get; set; } = null!;

    public string LecContenido { get; set; } = null!;

    public int EtapaId { get; set; }

    public int CursoId { get; set; }

    public DateTime LecFechaCreacion { get; set; }

    public bool LecActivo { get; set; }

    public int LecOrden { get; set; }

    public string LecTipo { get; set; } = null!;

    public int? LecPuntosRecompensa { get; set; }

    public int? LecNumeroIntentos { get; set; }

    public int? LecTiempoEstimado { get; set; }

    public virtual Curso? Curso { get; set; } 

    public virtual Etapa? Etapa { get; set; } 

    public virtual ICollection<PreguntasLeccion> PreguntasLeccions { get; set; } = new List<PreguntasLeccion>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
