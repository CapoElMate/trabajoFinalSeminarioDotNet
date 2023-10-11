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
    private readonly IRepositorioPrestamo repoPrestamo;
    private readonly IRepositorioLibro repoLibro;
    public RealizarPrestamoUseCase(IRepositorioPrestamo repoPrestamo, IRepositorioLibro repoLibro)
    {
        this.repoPrestamo = repoPrestamo;
        this.repoLibro = repoLibro;
    }
    
    /*METODO CANTLIBROS viejo
    private int cantLibrosPrestados(Prestamo prestamo){
        var listaPrestamos = _repo.listarPrestamos();

        int cant = 0;

        foreach (Prestamo p in listaPrestamos){
            if(p.libro == prestamo.libro ){
                cant++;
            }
        }

        return cant;
    }
    */

    private int obtenerCantEjemplaresLibro(int idLibro)
    {
        int cant = -1;

        try{
            Libro libro = repoLibro.verLibro(idLibro);
            cant = libro.numeroEjemplares;
        }
        catch(Exception e){
            Console.WriteLine("error obteniendo la cantidad de ejemplares del libro con id " + idLibro);            
            throw e;
        }

        return cant;
    }

    public void Ejecutar(Prestamo prestamo)
    {        
        //var listaPrestamosFiltradaPorId = new List<Prestamo>();
        
        int idLibro = prestamo.libro;

        if (repoPrestamo.cantLibrosPrestados(idLibro) < obtenerCantEjemplaresLibro(idLibro) ){
            repoPrestamo.realizarPrestamo(prestamo);    
        }
        else{
            throw new Exception("error, no hay libros disponibles con la id " + idLibro);
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