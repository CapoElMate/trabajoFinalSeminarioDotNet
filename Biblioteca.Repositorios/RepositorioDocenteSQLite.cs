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
        
    }


    public void modificarDocente(Docente docenteIngresado)
    {
        
    }



    public List<Docente> listarDocentes()
    {
        return new List<Docente>();
    }



}
