using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TareasContext : DbContext{
    public DbSet<Categoria> Categorias{get;set;}
    public DbSet<Tarea> Tareas{get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        List<Categoria>categoriaInit = new List<Categoria>();
        categoriaInit.Add(new Categoria() {CategoriaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38d4"), Nombre = "Actividades", Peso = 20  } );
        categoriaInit.Add(new Categoria() {CategoriaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38a5"), Nombre = "Personal", Peso = 10  } );

        modelBuilder.Entity<Categoria>(categoria=>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriaInit);
        });
        List<Tarea>tareaInit = new List<Tarea>();
        tareaInit.Add(new Tarea(){TareaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38c5"), CategoriaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38d4"), PrioridadTarea = Prioridad.Media, Titulo = "Tarea 1", Descripcion = "Descripcion de la tarea 1", FechaCreacion = DateTime.Now});
        tareaInit.Add(new Tarea(){TareaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38c1"), CategoriaId = Guid.Parse("91577f02-7653-450f-b9ad-7ec712ef38a5"), PrioridadTarea = Prioridad.Baja, Titulo = "Tarea 2", Descripcion = "Descripcion de la tarea 1", FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea =>{
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.resumen); 
            tarea.HasData(tareaInit);
        });
    }

    internal async Task SaveChangesAsync(Tarea tarea)
    {
        throw new NotImplementedException();
    }
}