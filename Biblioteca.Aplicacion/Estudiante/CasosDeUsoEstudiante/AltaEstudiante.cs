namespace Biblioteca.Aplicacion;


public class AltaEstudianteUseCase
{
    private readonly IRepositorioEstudiante _repo;
    public AltaEstudianteUseCase(IRepositorioEstudiante repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Estudiante estudiante)
    {
        _repo.altaEstudiante(estudiante);
    }
    
}