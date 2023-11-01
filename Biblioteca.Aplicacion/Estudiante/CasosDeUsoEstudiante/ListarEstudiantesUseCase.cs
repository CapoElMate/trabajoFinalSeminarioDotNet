namespace Biblioteca.Aplicacion;

public class ListarEstudiantesUseCase
{
    private readonly IRepositorioEstudiante _repo;

    public ListarEstudiantesUseCase(IRepositorioEstudiante repo)
    {
        this._repo = repo;
    }

    public List<Estudiante> Ejecutar()
    {
        return _repo.listarEstudiantes();
    }

}
