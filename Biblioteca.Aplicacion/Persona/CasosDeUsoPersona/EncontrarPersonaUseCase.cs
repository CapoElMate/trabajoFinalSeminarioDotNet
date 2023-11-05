namespace Biblioteca.Aplicacion;

public class EncontrarPersonaUseCase
{
    private readonly IRepositorioPersona _repo;

    public EncontrarPersonaUseCase(IRepositorioPersona repo)
    {
        this._repo = repo;
    }

    public Persona Ejecutar(int id)
    {
        return _repo.encontrarPersona(id);
    }

}
