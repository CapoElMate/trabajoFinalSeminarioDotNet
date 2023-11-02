using System.ComponentModel;
using Biblioteca.Aplicacion;
namespace Biblioteca.Repositorios;

public class RepositorioLibroSQLite: IRepositorioLibro
{


    public Libro verLibro(int idLibro){
        
        Libro libroRet;
        
        using(var db = new BibliotecaContext()){
            
            var libro = db.libros.Where(d => d.Id == idLibro).SingleOrDefault();
            
            if( libro != null )
                libroRet = libro;

            else    
                throw new Exception($"ERROR, el libro con el id {idLibro} no existe");

            db.SaveChanges();

        }

        return libroRet;
    }

    public void altaLibro(Libro libro)
    {
        using (var context = new BibliotecaContext()){
            context.Add(libro);            
            context.SaveChanges();
            
            context.Dispose();
        }
    }

    public void bajaLibro(int idLibro)
    {        
        using(var db = new BibliotecaContext()){
            
            var libroABorrar = db.libros.Where(d => d.Id == idLibro).SingleOrDefault();
            
            if( libroABorrar != null )
                db.Remove(libroABorrar);

            else    
                throw new Exception($"ERROR, el libro con el id {idLibro} no existe");

            db.SaveChanges();

        }
    }


    public void modificarLibro(Libro libroIngresado)
    {
        using(var db = new BibliotecaContext()){
            
            var libroModificar = db.libros.Where(d => d.Id == libroIngresado.Id).SingleOrDefault();
            
            if(libroModificar != null){
                db.Remove(libroModificar);
                db.Add(libroIngresado);
            }

            else    
                throw new Exception($"ERROR, el libro con el id {libroIngresado.Id} no existe");

            db.SaveChanges();

        }
    }



    public List<Libro> listarLibros()
    {
        List<Libro> libros;

        using(var db = new BibliotecaContext()){

            libros = db.libros.ToList();

        }

        return libros;
    }



}
