namespace Biblioteca.Aplicacion;


public class AltaLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public AltaLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Libro libro)
    {
        _repo.altaLibro(libro);
    }
    
}