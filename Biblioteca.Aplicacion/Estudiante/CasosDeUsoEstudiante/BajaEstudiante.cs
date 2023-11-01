namespace Biblioteca.Aplicacion;



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