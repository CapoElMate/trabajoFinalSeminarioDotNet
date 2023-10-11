namespace Biblioteca.Aplicacion;

public class AltaLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public AltaLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Libro libro)
    {
        _repo.altaLibro(libro);
    }
    
}

public class BajaLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public BajaLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(int idLibro)
    {
        _repo.bajaLibro(idLibro);
    }
    
}

public class VerLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public VerLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public Libro Ejecutar(int idLibro)
    {
        return _repo.verLibro(idLibro);
    }
    
}

public class ModificarLibroUseCase
{
    private readonly IRepositorioLibro _repo;
    public ModificarLibroUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }
    public void Ejecutar(Libro libro)
    {
        _repo.modificarLibro(libro);
    }
    
}

public class ListarLibrosUseCase
{
    private readonly IRepositorioLibro _repo;

    public ListarLibrosUseCase(IRepositorioLibro repo)
    {
        this._repo = repo;
    }

    public List<Libro> Ejecutar()
    {
        return _repo.ListarLibros();
    }

}