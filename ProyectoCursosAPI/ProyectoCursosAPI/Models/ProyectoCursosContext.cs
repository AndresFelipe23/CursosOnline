using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCursosAPI.Models;

public partial class ProyectoCursosContext : DbContext
{
    public ProyectoCursosContext()
    {
    }

    public ProyectoCursosContext(DbContextOptions<ProyectoCursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Etapa> Etapas { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Leccione> Lecciones { get; set; }

    public virtual DbSet<Logro> Logros { get; set; }

    public virtual DbSet<OpcionesPreguntum> OpcionesPregunta { get; set; }

    public virtual DbSet<PreguntasLeccion> PreguntasLeccions { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<ProgresoEtapa> ProgresoEtapas { get; set; }

    public virtual DbSet<RespuestasUsuario> RespuestasUsuarios { get; set; }

    public virtual DbSet<UsuarioLogro> UsuarioLogros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ProyectoCursos;User Id=sa;Password=1003403445;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D716E82090");

            entity.Property(e => e.CurActivo).HasDefaultValue(true);
            entity.Property(e => e.CurFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurNivelDificultad).HasMaxLength(50);
            entity.Property(e => e.CurProfesorUid)
                .HasMaxLength(128)
                .HasColumnName("CurProfesorUID");
            entity.Property(e => e.CurTitulo).HasMaxLength(255);
        });

        modelBuilder.Entity<Etapa>(entity =>
        {
            entity.HasKey(e => e.EtapaId).HasName("PK__Etapas__402706E4418C9393");

            entity.Property(e => e.EtaActivo).HasDefaultValue(true);
            entity.Property(e => e.EtaFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EtaNombre).HasMaxLength(255);
            entity.Property(e => e.EtaNumeroLecciones).HasDefaultValue(0);

            entity.HasOne(d => d.Curso).WithMany(p => p.Etapas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Etapas__CursoId__3E52440B");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PK__Evaluaci__99ABA74567601B93");

            entity.Property(e => e.EvalFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EvalTitulo).HasMaxLength(255);

            entity.HasOne(d => d.Curso).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__Curso__5FB337D6");

            entity.HasOne(d => d.Etapa).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.EtapaId)
                .HasConstraintName("FK__Evaluacio__Etapa__60A75C0F");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PK__Inscripc__168316B930A72D35");

            entity.Property(e => e.InsEstado)
                .HasMaxLength(50)
                .HasDefaultValue("Inscrito");
            entity.Property(e => e.InsFechaInscripcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InsProgresoTotal).HasDefaultValue(0.0);
            entity.Property(e => e.UsuarioUid)
                .HasMaxLength(128)
                .HasColumnName("UsuarioUID");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripci__Curso__5441852A");
        });

        modelBuilder.Entity<Leccione>(entity =>
        {
            entity.HasKey(e => e.LeccionId).HasName("PK__Leccione__5C59E7C39241CEDA");

            entity.Property(e => e.LecActivo).HasDefaultValue(true);
            entity.Property(e => e.LecFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LecNumeroIntentos).HasDefaultValue(1);
            entity.Property(e => e.LecPuntosRecompensa).HasDefaultValue(0);
            entity.Property(e => e.LecTiempoEstimado).HasDefaultValue(0);
            entity.Property(e => e.LecTipo).HasMaxLength(50);
            entity.Property(e => e.LecTitulo).HasMaxLength(255);

            entity.HasOne(d => d.Curso).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lecciones__Curso__4D94879B");

            entity.HasOne(d => d.Etapa).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.EtapaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lecciones__Etapa__4CA06362");
        });

        modelBuilder.Entity<Logro>(entity =>
        {
            entity.HasKey(e => e.LogroId).HasName("PK__Logros__A54B4F403C04FC5F");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogroNombre).HasMaxLength(255);
        });

        modelBuilder.Entity<OpcionesPreguntum>(entity =>
        {
            entity.HasKey(e => e.OpcionId).HasName("PK__Opciones__77CD086371C5825E");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.OpcionesPregunta)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OpcionesP__Pregu__6E01572D");
        });

        modelBuilder.Entity<PreguntasLeccion>(entity =>
        {
            entity.HasKey(e => e.PreguntaId).HasName("PK__Pregunta__EBB2A379D9D3681C");

            entity.ToTable("PreguntasLeccion");

            entity.Property(e => e.TipoPregunta).HasMaxLength(50);

            entity.HasOne(d => d.Leccion).WithMany(p => p.PreguntasLeccions)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__Lecci__6B24EA82");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.ProgresoId).HasName("PK__Progreso__B9EABD660A09C5E3");

            entity.ToTable("Progreso");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("No iniciado");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioUid)
                .HasMaxLength(128)
                .HasColumnName("UsuarioUID");

            entity.HasOne(d => d.Curso).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Progreso__CursoI__59FA5E80");

            entity.HasOne(d => d.Etapa).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.EtapaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Progreso__EtapaI__5AEE82B9");

            entity.HasOne(d => d.Leccion).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Progreso__Leccio__5BE2A6F2");
        });

        modelBuilder.Entity<ProgresoEtapa>(entity =>
        {
            entity.HasKey(e => e.ProgresoEtapaId).HasName("PK__Progreso__6C669AB8DEE2FD51");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("No iniciado");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioUid)
                .HasMaxLength(128)
                .HasColumnName("UsuarioUID");

            entity.HasOne(d => d.Curso).WithMany(p => p.ProgresoEtapas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgresoE__Curso__440B1D61");

            entity.HasOne(d => d.Etapa).WithMany(p => p.ProgresoEtapas)
                .HasForeignKey(d => d.EtapaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgresoE__Etapa__44FF419A");
        });

        modelBuilder.Entity<RespuestasUsuario>(entity =>
        {
            entity.HasKey(e => e.RespuestaId).HasName("PK__Respuest__31F7FC11D97FECF6");

            entity.ToTable("RespuestasUsuario");

            entity.Property(e => e.FechaRespuesta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioUid)
                .HasMaxLength(128)
                .HasColumnName("UsuarioUID");

            entity.HasOne(d => d.Opcion).WithMany(p => p.RespuestasUsuarios)
                .HasForeignKey(d => d.OpcionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Opcio__72C60C4A");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.RespuestasUsuarios)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__Pregu__71D1E811");
        });

        modelBuilder.Entity<UsuarioLogro>(entity =>
        {
            entity.HasKey(e => e.UsuarioLogroId).HasName("PK__UsuarioL__4575C9885216683B");

            entity.Property(e => e.FechaOtorgamiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioUid)
                .HasMaxLength(128)
                .HasColumnName("UsuarioUID");

            entity.HasOne(d => d.Logro).WithMany(p => p.UsuarioLogros)
                .HasForeignKey(d => d.LogroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioLo__Logro__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
