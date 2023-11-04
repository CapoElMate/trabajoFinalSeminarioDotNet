namespace Biblioteca.Aplicacion;

public class ListarPersonasUseCase
{
    private readonly IRepositorioPersona _repo;

    public ListarPersonasUseCase(IRepositorioPersona repo)
    {
        this._repo = repo;
    }

    public List<Persona> Ejecutar()
    {
        return _repo.listarPersonas();
    }

}
