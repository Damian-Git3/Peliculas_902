using Microsoft.EntityFrameworkCore;
using TareasAPI_902.Models;

namespace TareasAPI_902.Models;

public partial class BdTareas902Context : DbContext
{
    public BdTareas902Context()
    {
    }

    public BdTareas902Context(DbContextOptions<BdTareas902Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__tarea__C0ECF7075BEFB7FD");

            entity.ToTable("tarea");

            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<TareasAPI_902.Models.Pelicula> Pelicula { get; set; } = default!;
}
