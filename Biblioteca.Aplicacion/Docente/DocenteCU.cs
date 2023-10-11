using Biblioteca.Aplicacion;

namespace Almacen.Aplicacion;  

public class altaDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public altaDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Docente docente)
    {
        _repo.altaDocente(docente);
    }
    
}

public class BajaDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public BajaDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int id)
    {
        _repo.bajaDocente(id);
    }
    
}

public class modificarDocenteUseCase   
{
    private readonly IRepositorioDocente _repo;
    public modificarDocenteUseCase(IRepositorioDocente repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Docente docente)
    {
        _repo.modificarDocente(docente);
    }
    
}

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