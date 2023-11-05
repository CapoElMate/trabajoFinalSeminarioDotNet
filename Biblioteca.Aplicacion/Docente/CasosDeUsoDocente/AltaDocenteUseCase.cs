namespace Biblioteca.Aplicacion;  


public class AltaDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public AltaDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Docente docente)
    {
        _repo.altaDocente(docente);
    }
    
}