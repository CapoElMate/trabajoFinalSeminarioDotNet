namespace Biblioteca.Aplicacion;


public class ListarLibrosUseCase
{
    private readonly IRepositorioLibro _repo;
    public ListarLibrosUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }

    public List<Libro> Ejecutar()
    {
        return _repo.listarLibros();
    }

}