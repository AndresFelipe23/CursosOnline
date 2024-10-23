using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class Progreso
{
    public int ProgresoId { get; set; }

    public string UsuarioUid { get; set; } = null!;

    public int CursoId { get; set; }

    public int EtapaId { get; set; }

    public int LeccionId { get; set; }

    public string Estado { get; set; } = null!;

    public double Porcentaje { get; set; }

    public DateTime FechaUltimaActualizacion { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual Etapa Etapa { get; set; } = null!;

    public virtual Leccione Leccion { get; set; } = null!;
}
