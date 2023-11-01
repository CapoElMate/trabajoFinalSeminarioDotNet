namespace Biblioteca.Aplicacion;


public class VerLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public VerLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public Libro Ejecutar(int idLibro)
    {
        return _repo.verLibro(idLibro);
    }
    
}