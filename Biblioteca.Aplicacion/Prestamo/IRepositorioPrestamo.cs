namespace Biblioteca.Aplicacion;

public interface IRepositorioPrestamo{

    int cantLibrosPrestados(int idLibro);

    void realizarPrestamo(Prestamo prestamo);
    void devolverLibro(Prestamo devolucion);   

    List<Prestamo> listarPrestamos();

    List<Prestamo> listarPrestamosActivos();
}