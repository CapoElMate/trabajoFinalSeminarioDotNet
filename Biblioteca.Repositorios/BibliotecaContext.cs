using Microsoft.EntityFrameworkCore;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class BibliotecaContext : DbContext
{

    #nullable disable

   public DbSet<Persona> personas { get; set; } 
   public DbSet<Docente> docentes { get; set; }
   public DbSet<Estudiante> estudiantes { get; set; }
   public DbSet<Libro> libros { get; set; }
   public DbSet<Prestamo> prestamos { get; set; }
    
    #nullable restore

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("data source=Biblioteca.sqlite");
   }
}