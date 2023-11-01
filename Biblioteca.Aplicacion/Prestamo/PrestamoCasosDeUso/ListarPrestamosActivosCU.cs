using System.Net.Cache;
namespace Biblioteca.Aplicacion;



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