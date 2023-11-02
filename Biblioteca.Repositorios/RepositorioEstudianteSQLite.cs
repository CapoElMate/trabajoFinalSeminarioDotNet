using System.ComponentModel;
using Biblioteca.Aplicacion;
namespace Biblioteca.Repositorios;

public class RepositorioEstudianteSQLite: IRepositorioEstudiante
{



    public void altaEstudiante(Estudiante estudiante)
    {
        using (var context = new BibliotecaContext()){
            context.Add(estudiante);            
            context.SaveChanges();
            
            context.Dispose();
        }
    }

    public void bajaEstudiante(int idEstudiante)
    {        
        using(var db = new BibliotecaContext()){
            
            var estudianteABorrar = db.estudiantes.Where(d => d.Id == idEstudiante).SingleOrDefault();
            
            if( estudianteABorrar != null )
                db.Remove(estudianteABorrar);

            else    
                throw new Exception($"ERROR, el estudiante con el id {idEstudiante} no existe");

            db.SaveChanges();

        }
    }


    public void modificarEstudiante(Estudiante estudianteIngresado)
    {
        using(var db = new BibliotecaContext()){
            
            var estudianteModificar = db.estudiantes.Where(d => d.Id == estudianteIngresado.Id).SingleOrDefault();
            
            if(estudianteModificar != null){
                db.Remove(estudianteModificar);
                db.Add(estudianteIngresado);
            }

            else    
                throw new Exception($"ERROR, el estudiante con el id {estudianteIngresado.Id} no existe");

            db.SaveChanges();

        }
    }



    public List<Estudiante> listarEstudiantes()
    {
        List<Estudiante> estudiantes;

        using(var db = new BibliotecaContext()){

            estudiantes = db.estudiantes.ToList();

        }

        return estudiantes;
    }



}
