using System.ComponentModel;
using Biblioteca.Aplicacion;
namespace Biblioteca.Repositorios;

public class RepositorioPrestamoSQLite: IRepositorioPrestamo
{



    public void realizarPrestamo(Prestamo prestamo)
    {
        using (var context = new BibliotecaContext()){
            context.Add(prestamo);            
            context.SaveChanges();
            
            context.Dispose();
        }
    }

    public void devolverLibro(Prestamo prestamo)
    {     

        if(!prestamo.estaDevuelto)
            throw new Exception($"ERROR, el prestamo pasado como parametro no fue devuelto.");

        using(var db = new BibliotecaContext()){
            
            var docenteABorrar = db.prestamos.Where(p => p.id == prestamo.id).SingleOrDefault();
            
            if( docenteABorrar != null ){
                db.Remove(docenteABorrar);
                db.Add(prestamo);
            }
                
            else    
                throw new Exception($"ERROR, el prestamo con el id {prestamo.id} no existe");

            db.SaveChanges();

        }
    }

    public List<Prestamo> listarPrestamosActivos()
    {
        List<Prestamo> lPrestamos;

        using(var db = new BibliotecaContext()){

            lPrestamos = db.prestamos.Where(p => p.estaDevuelto).ToList();

        }

        return lPrestamos;
    }

    public List<Prestamo> listarPrestamos()
    {
        List<Prestamo> lPrestamos;

        using(var db = new BibliotecaContext()){

            lPrestamos = db.prestamos.ToList();

        }

        return lPrestamos;
    }

    public int cantLibrosPrestados(int idLibro){
        int cant = 0;

        using(var db = new BibliotecaContext()){

            cant = db.prestamos.Where(p => (p.LibroId == idLibro) && !p.estaDevuelto).Count();

        }

        return cant;
    }


}
