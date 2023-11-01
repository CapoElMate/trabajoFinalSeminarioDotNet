namespace Biblioteca.Aplicacion;


public class BajaLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public BajaLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int idLibro)
    {
        _repo.bajaLibro(idLibro);
    }
    
}