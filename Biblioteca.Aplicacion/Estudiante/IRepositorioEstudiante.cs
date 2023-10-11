namespace Biblioteca.Aplicacion;

public interface IRepositorioEstudiante{

    void altaEstudiante(Estudiante estudiante);
    void bajaEstudiante(int idEstudiante);
    void modificarEstudiante(Estudiante estudiante);
    List<Estudiante> ListarEstudiantes();

}