using System.Net.Cache;

namespace Biblioteca.Aplicacion;

/*
    void realizarPrestamo(Prestamo prestamo);
    void devolverLibro(Prestamo devolucion);

    List<Prestamo> listarPrestamos();

    List<Prestamo> listarPrestamosActivos();
*/

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

        try{
            Libro libro = repoLibro.verLibro(idLibro);  //tomo el valor del libro con ese id
            cant = libro.numeroEjemplares;              
        }
        catch(Exception e){
            Console.WriteLine("error obteniendo la cantidad de ejemplares del libro con id " + idLibro + e); 
        }

        return cant;
    }

    public void Ejecutar(Prestamo prestamo)
    {   
        
        int idLibro = prestamo.libro; 
        
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

public class DevolverLibroUseCase
{
    private readonly IRepositorioPrestamo _repo;
    public DevolverLibroUseCase(IRepositorioPrestamo repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Prestamo prestamo)
    {
        _repo.devolverLibro(prestamo);
    }
}

public class ListarPrestamosUseCase
{
    private readonly IRepositorioPrestamo _repo;
    public ListarPrestamosUseCase(IRepositorioPrestamo repo)
    {
        this._repo = repo;
    }
    public List<Prestamo> Ejecutar()
    {
        return _repo.listarPrestamos();
    }
}

public class ListarPrestamosActivosUseCase
{
    private readonly IRepositorioPrestamo _repo;
    public ListarPrestamosActivosUseCase(IRepositorioPrestamo repo)
    {
        this._repo = repo;
    }
    public List<Prestamo> Ejecutar()
    {
        var lista = _repo.listarPrestamos();
        var retLista = new List<Prestamo>();

        foreach (Prestamo p in lista){
            if(p.estaDevuelto == false){
                retLista.Add(p);
            }
        }

        return retLista;
    }
}