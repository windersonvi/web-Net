using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using projectEF.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async([FromServices] TareasContext dbContext) =>{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Database created {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/readtareas",async( [FromServices] TareasContext dbContext )=>{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/createtareas",async( [FromServices] TareasContext dbContext, [FromBody] Tarea tarea )=>{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok("Se creo una tarea");
});
app.MapPut("/api/updatetareas/{id}",async( [FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id )=>{
    
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null){
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Descripcion = tarea.Descripcion;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        await dbContext.SaveChangesAsync();
        return Results.Ok("Se encontro la tarea y se actualizo");
    }
    return Results.NotFound("No se encontro la tarea");
});

app.MapDelete("/api/deletetareas/{id}",async( [FromServices] TareasContext dbContext, [FromRoute] Guid id )=>{
    var tarea = dbContext.Tareas.Find(id);
    if (tarea != null){
        dbContext.Tareas.Remove(tarea);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Se encontro la tarea y se elimino");
    }
    return Results.NotFound("No se encontro la tarea");
});

app.Run();
