using System.ComponentModel;
using Biblioteca.Aplicacion;
namespace Biblioteca.Repositorios;

public class RepositorioDocenteSQLite: IRepositorioDocente
{



    public void altaDocente(Docente docente)
    {
        using (var context = new BibliotecaContext()){
            context.Add(docente);            
            context.SaveChanges();
            
            context.Dispose();
        }
    }

    public void bajaDocente(int idDocente)
    {        
        using(var db = new BibliotecaContext()){
            
            var docenteABorrar = db.docentes.Where(d => d.Id == idDocente).SingleOrDefault();
            
            if( docenteABorrar != null )
                db.Remove(docenteABorrar);

            else    
                throw new Exception($"ERROR, el docente con el id {idDocente} no existe");

            db.SaveChanges();

        }
    }


    public void modificarDocente(Docente docenteIngresado)
    {
        using(var db = new BibliotecaContext()){
            
            var docenteModificar = db.docentes.Where(d => d.Id == docenteIngresado.Id).SingleOrDefault();
            
            if(docenteModificar != null){
                db.Remove(docenteModificar);
                db.Add(docenteIngresado);
            }

            else    
                throw new Exception($"ERROR, el docente con el id {docenteIngresado.Id} no existe");

            db.SaveChanges();

        }
    }



    public List<Docente> listarDocentes()
    {
        List<Docente> docentes;

        using(var db = new BibliotecaContext()){

            docentes = db.docentes.ToList();

        }

        return docentes;
    }



}
