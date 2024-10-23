using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Etapa
{
    public int EtapaId { get; set; }

    public string EtaNombre { get; set; } = null!;

    public string? EtaDescripcion { get; set; }

    public int CursoId { get; set; }

    public int EtaOrden { get; set; }

    public DateTime EtaFechaCreacion { get; set; }

    public bool EtaActivo { get; set; }

    public int? EtaNumeroLecciones { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();

    public virtual ICollection<ProgresoEtapa> ProgresoEtapas { get; set; } = new List<ProgresoEtapa>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
