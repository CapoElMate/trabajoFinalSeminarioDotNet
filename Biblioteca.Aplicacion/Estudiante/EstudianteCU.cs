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

public class BajaEstudianteUseCase
{
    private readonly IRepositorioEstudiante _repo;
    public BajaEstudianteUseCase(IRepositorioEstudiante repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int idEstudiante)
    {
        _repo.bajaEstudiante(idEstudiante);
    }
    
}


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