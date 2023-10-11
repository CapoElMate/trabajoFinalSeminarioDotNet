namespace Biblioteca.Aplicacion;

public interface IRepositorioPrestamo{

    int cantLibrosPrestados(int idLibro); // esta funcion solo se usa internamente en el Caso de Uso

    void realizarPrestamo(Prestamo prestamo);
    void devolverLibro(Prestamo devolucion);   

    List<Prestamo> listarPrestamos();

    List<Prestamo> listarPrestamosActivos();
}