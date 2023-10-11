namespace Biblioteca.Aplicacion;

public interface IRepositorioLibro
{
    public void altaLibro(Libro libro);
    public Libro verLibro(int idLibro);
    public void bajaLibro(int idLibro);
    public void modificarLibro(Libro libro);
    public List<Libro> ListarLibros();

}