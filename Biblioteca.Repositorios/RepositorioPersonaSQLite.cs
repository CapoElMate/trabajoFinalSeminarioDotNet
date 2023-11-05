using System.ComponentModel;
using Biblioteca.Aplicacion;
namespace Biblioteca.Repositorios;

public class RepositorioPersonaSQLite: IRepositorioPersona
{


    public List<Persona> listarPersonas()
    {
        List<Persona> personas;

        using(var db = new BibliotecaContext()){

            personas = db.personas.ToList();

        }

        return personas;
    }

    public Persona encontrarPersona(int id){
        Persona? persona;

        using(var db = new BibliotecaContext()){

            //busca la persona con el id ID , si no la encuentra devuelve una persona vacia.
            persona = db.personas.ToList().Where(p => p.Id == id).FirstOrDefault();

            if(persona == null)
                throw new Exception($"error, no se encontro la persona con el id {id} ");

        }

        return persona;
    }



}
