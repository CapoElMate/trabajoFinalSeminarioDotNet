namespace Biblioteca.Aplicacion;  


public class ListarDocentesUseCase
{
    private readonly IRepositorioDocente _repo;

    public ListarDocentesUseCase(IRepositorioDocente repo){
        this._repo = repo;
    }

    public List<Docente> Ejecutar(){
        return _repo.listarDocentes();
    }

}