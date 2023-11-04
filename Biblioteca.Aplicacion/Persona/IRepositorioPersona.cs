namespace Biblioteca.Aplicacion;

public interface IRepositorioPersona{

    List<Persona> listarPersonas();
    Persona encontrarPersona(int id);

}