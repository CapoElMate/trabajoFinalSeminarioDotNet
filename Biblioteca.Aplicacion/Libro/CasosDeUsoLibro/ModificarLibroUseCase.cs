namespace Biblioteca.Aplicacion;


public class ModificarLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public ModificarLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Libro libro)
    {
        _repo.modificarLibro(libro);
    }
    
}