namespace Biblioteca.Aplicacion;

public class ModificarEstudianteUseCase
{
    private readonly IRepositorioEstudiante _repo;
    public ModificarEstudianteUseCase(IRepositorioEstudiante repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Estudiante estudiante)
    {
        _repo.modificarEstudiante(estudiante);
    }
    
}