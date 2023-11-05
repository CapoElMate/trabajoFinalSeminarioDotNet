using System.Net.Cache;
namespace Biblioteca.Aplicacion;



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