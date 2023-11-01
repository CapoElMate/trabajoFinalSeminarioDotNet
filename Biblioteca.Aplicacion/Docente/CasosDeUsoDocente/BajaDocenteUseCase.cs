namespace Biblioteca.Aplicacion;  

public class BajaDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public BajaDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int id)
    {
        _repo.bajaDocente(id);
    }
    
}