using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoCursosAPI.Models;

public partial class Curso
{
    public int CursoId { get; set; }

    public string CurTitulo { get; set; } = null!;

    public string? CurDescripcion { get; set; }

    public string CurProfesorUid { get; set; } = null!;

    public DateTime CurFechaCreacion { get; set; }

    public bool CurActivo { get; set; }

    public int CurDuracion { get; set; }

    public string CurNivelDificultad { get; set; } = null!;

    public string CurImagenUrl { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Etapa> Etapas { get; set; } = new List<Etapa>();

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();

    public virtual ICollection<ProgresoEtapa> ProgresoEtapas { get; set; } = new List<ProgresoEtapa>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
