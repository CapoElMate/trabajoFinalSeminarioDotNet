using System.Net.Cache;
namespace Biblioteca.Aplicacion;



public class ListarPrestamosCU
{
    private readonly IRepositorioPrestamo _repo;
    public ListarPrestamosCU(IRepositorioPrestamo repo)
    {
        this._repo = repo;
    }
    public List<Prestamo> Ejecutar()
    {
        return _repo.listarPrestamos();
    }
}