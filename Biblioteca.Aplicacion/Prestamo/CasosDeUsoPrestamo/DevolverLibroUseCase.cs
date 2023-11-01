using System.Net.Cache;

namespace Biblioteca.Aplicacion;


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
