using System.ComponentModel;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class RepositorioLibroTxt: IRepositorioLibro
{

    readonly protected string nombreArchivo = "libros.txt";

    public void altaLibro(Libro libro)
    {
        //NOTA: no checkeo si se repite el id del libro, no deberia pasar.
        libro.id = IDmanager.Obtener("libro");  //modifica el id del libro para tener el de id manager
        IDmanager.Modificar("libro",libro.id+1);//hace que el id para esta categoria aumente en 1

        using var sw = new StreamWriter(nombreArchivo, true);//construyo un stream writer

        sw.WriteLine(libro.ToString());//guardo el libro en la prox. linea
        sw.Close();//cierro el stream writer
    }


    public Libro verLibro(int idLibro){
        
        //creo una lista de libros
        var Libros = listarLibros();
        //la variable de retorno libro es nula:
        Libro? libro = null;

        //por cada libro en libros, comparo si el id es igual al del ingresado.
        foreach(Libro l in Libros){
            if( ( libro!=null ) && l.id == libro.id){
                return l; // en caso de que esto se cumpla, retorno l y termino la funcion.
            }                
        }


        if (libro == null)
                throw new DataException("no se encontro el libro con el id: " + idLibro);//NOTA: use data exeption pero no sabia que exepcion usar
        

        return libro;
    }


    public void bajaLibro(int idLibro)
    {
        // este codigo va a consistir en cargar la lista en ListaLibros,
        // e ir cargando todos los libros excepto el que tiene la id igual al que le enviamos.
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaLibros = listarLibros();

        using var sw = new StreamWriter(nombreArchivo);

        bool seEncontro = false;


        foreach( Libro libro in listaLibros ){

           //aca divide el substring y verifica que el id sea igual o no.            
            if( libro.id != idLibro) {
                sw.WriteLine(libro.ToString());
            }
            else
            {
                seEncontro = true;
            }

        }

        if(!seEncontro){
            throw new Exception("no se encontro para eliminar el libro con el id " + idLibro);
        }

    }


    public void modificarLibro(Libro libroIngresado)
    {
        // este codigo va a consistir en cargar la lista en memoria,
        // buscar el libro que tenga una id coincidente con el que le enviamos,        
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaLibros = listarLibros();

        bool encontrado = false;
        
        
        //aqui uso un while en vez de un for para salir cuando encuentro el libro
        int i = 0;
        while(!encontrado && i<listaLibros.Count()){
            
            if(listaLibros[i].id == libroIngresado.id){
                encontrado = true;
                listaLibros[i] = libroIngresado;
            }

            i++;
        }

        //si no encontro el libro tiro un error.
        if(!encontrado)
            throw new Exception("no se encontro un libro con ese id.");

        
        using(var sw = new StreamWriter(nombreArchivo,false)){ // creo un nuevo streamwriter, append en false asi sobreescribe el anterior.
            
            foreach(Libro libro in listaLibros){
                sw.WriteLine(libro.ToString());
            }
        }
        
        

    }



    public List<Libro> listarLibros(){
        var listaLibros = new List<Libro>();

        using (var sr = new StreamReader(nombreArchivo))
        {
            string? linea;

            while(!sr.EndOfStream)
            {
                linea = sr.ReadLine();
            
                if (linea != null){
                    listaLibros.Add( stringALibro(linea) );
                }
            }
        }

        return listaLibros;
    }

    private Libro stringALibro(string[] subLinea)
    {        
        
        if(subLinea.Length != 6){
            throw new Exception("string de datos invalido, cantidad de parametros del libro incorrectas"); 
        }
        
        //creo un nuevo libro basandome en el formato:
        //$"{id},{autor},{titulo},{añoPublicacion},{genero},{numeroEjemplares}";  
        return new Libro ( int.Parse(subLinea[0]) , subLinea[1] , subLinea[2] , int.Parse(subLinea[3]) , subLinea[4] , int.Parse(subLinea[5]) );
    }

    private Libro stringALibro(string strInfoLibro)
    {        
        string[] subLinea = strInfoLibro.Split(',');
        
        return stringALibro(subLinea);        
    }
}
