using System.Net.Cache;
namespace Biblioteca.Aplicacion;



public class RealizarPrestamoUseCase
{
    //en este codigo tuve que acceder a las dos interfaces, 
    //porque para saber si quedan libros disponibles que prestar, debo acceder a la cantidad de copias de ese libro.

    private readonly IRepositorioPrestamo repoPrestamo; 
    private readonly IRepositorioLibro repoLibro;
    public RealizarPrestamoUseCase(IRepositorioPrestamo repoPrestamo, IRepositorioLibro repoLibro)
    {
        this.repoPrestamo = repoPrestamo;
        this.repoLibro = repoLibro;
    }
    
    
    //en este metodo accedo al libro con ese id y devuelvo la cantidad de copias que hay del mismo.
    private int obtenerCantEjemplaresLibro(int idLibro)
    {
        int cant = -1; //inicializo el valor de retorno

    
        Libro libro = repoLibro.verLibro(idLibro);  //tomo el valor del libro con ese id
        cant = libro.numeroEjemplares;              
    

        return cant;
    }

    public void Ejecutar(Prestamo prestamo)
    {   
        
        int idLibro = prestamo.LibroId; 
        
        //Console.WriteLine(repoPrestamo.cantLibrosPrestados(idLibro) + "<" + obtenerCantEjemplaresLibro(idLibro) +"?"); //DEBUG
        
        //si hay por lo menos un libro disponible, presta el libro
        if (repoPrestamo.cantLibrosPrestados(idLibro) < obtenerCantEjemplaresLibro(idLibro) ){
            repoPrestamo.realizarPrestamo(prestamo);   
        }
        else{
            //si no, tira error.
            throw new Exception("error, no hay mas libros disponibles con la id " + idLibro);
        }

    }
}