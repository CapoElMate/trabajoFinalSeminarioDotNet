namespace Biblioteca.Aplicacion;

public interface IRepositorioDocente{

    void altaDocente(Docente docente);
    void bajaDocente(int idDocente);
    void modificarDocente(Docente docente);
    List<Docente> ListarDocentes();

}
