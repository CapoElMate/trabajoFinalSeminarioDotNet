namespace Biblioteca.Aplicacion;  

public class ModificarDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public ModificarDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Docente docente)
    {
        _repo.modificarDocente(docente);
    }
    
}