using System;
using System.Collections.Generic;

namespace ProyectoCursosAPI.Models;

public partial class UsuarioLogro
{
    public int UsuarioLogroId { get; set; }

    public string UsuarioUid { get; set; } = null!;

    public int LogroId { get; set; }

    public DateTime FechaOtorgamiento { get; set; }

    public virtual Logro Logro { get; set; } = null!;
}
