using System.ComponentModel;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class RepositorioLibroTxt: IRepositorioLibro
{

    readonly protected string nombreArchivo = "libros.txt";

    public void altaLibro(Libro libro)
    {
        libro.id = IDmanager.Obtener("libro");  //modifica el id del libro para tener el de id manager
        IDmanager.Modificar("libro",libro.id+1);//hace que el id para esta categoria aumente en 1

        using var sw = new StreamWriter(nombreArchivo, true);//construyo un stream writer

        sw.WriteLine(libro.ToString());//guardo el libro en la prox. linea
        sw.Close();//cierro el stream writer
    }



    
    //checkear idea: ver libro pordria usar la lista y el codigo seria mucho mas facil.
    public Libro verLibro(int idLibro)
    {
        Libro? libro = null;
        bool encontrado = false;
        using var sr = new StreamReader(nombreArchivo);
        
        while(!encontrado && !sr.EndOfStream)
        {            
            string[] subLinea = sr.ReadLine().Split(',');

            //si el id actual es igual al ingresado:
            if( subLinea[0].Equals( idLibro.ToString() )){
                libro = stringALibro(subLinea);                
                encontrado = true;//NOTA: use un boolean porque no se si esta bueno usar el break
            }
        }

        if (libro == null)
            throw new DataException("no se encontro el libro con el id: " + idLibro);//NOTA: use data exeption pero no sabia que exepcion usar

        sr.Close();
        
        return libro;
    }

//checkear
/*
    public void bajaLibro(int idLibro)
    {
        
        string[] strSubLibros;

        using (var sr = new StreamReader(nombreArchivo)){
            strSubLibros = sr.ReadToEnd().Split(Environment.NewLine); //string subdividido con la info de los libros.
        }
        
        

        //la idea seria, guardar el repo en substring, recorrerlo e ir añadiendo los elementos.
        //si el elemento es igual lo saltea, no lo añade.

        bool seEncontro = false; //variable para registrar si se encontro la variable.
        using var sw = new StreamWriter(nombreArchivo); //append en false, para que remplaze lo anterior.

        foreach( string str in strSubLibros ){

            Console.WriteLine(str.Split(',')[0].Equals( idLibro.ToString() ));//DEBUG

           //aca divide el substring y verifica que el id sea igual o no.            
            if( ! str.Split(',')[0].Equals( idLibro.ToString() )  && !str.Equals(Environment.NewLine)){
                sw.Write(str);
                seEncontro = true;
            }

        }

        if(!seEncontro){
            throw new DataException("no se encontro el libro con el id: " + idLibro);//NOTA: use data exeption pero no sabia que exepcion usar
        }
    }
*/

    public void bajaLibro(int idLibro)
    {
        var listaLibros = ListarLibros();

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

//checkear: falta escribir el metodo
    public void modificarLibro(Libro libro)
    {

    }

//checkear
/*
    public List<Libro> ListarLibros()
    {
        var listaLibros = new List<Libro>();
        
        var sr = new StreamReader(nombreArchivo);
        
        string[] subStrings = sr.ReadToEnd().Split('\n');
        
        sr.Close();
        
        foreach( string str in subStrings ){
            
            // try{
                listaLibros.Add( stringALibro(str) );
            // }
            // catch(Exception e){
            //     if(e.ToString().Equals("string de datos invalido, faltan parametros sobre el libro"))
            //         Console.WriteLine("EROR LEYENDO UNA LINEA");
            //     else
            //         throw e;

            // }
            
        }
        
        return listaLibros;
    }
*/

    public List<Libro> ListarLibros(){
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
        
        if(subLinea.Length < 6){
            //throw new Exception("string de datos invalido, faltan parametros sobre el libro"); //checkear
        }
        
        //creo un nuevo libro basandome en el formato:
        //$"{id},{autor},{titulo},{añoPublicacion},{genero},{numeroEjemplares}";  
        return new Libro ( int.Parse(subLinea[0]) , subLinea[1] , subLinea[2] , int.Parse(subLinea[3]) , subLinea[4] , int.Parse(subLinea[5]) );
    }

    private Libro stringALibro(string strInfoLibro)
    {        
        string[] subLinea = strInfoLibro.Split(',');
        
        if(subLinea.Length < 6){
            //throw new Exception("string de datos invalido, faltan parametros sobre el libro");//checkear
        }
        
        //creo un nuevo libro basandome en el formato:
        //$"{id},{autor},{titulo},{añoPublicacion},{genero},{numeroEjemplares}";   
        return new Libro ( int.Parse(subLinea[0]) , subLinea[1] , subLinea[2] , int.Parse(subLinea[3]) , subLinea[4] , int.Parse(subLinea[5]) );
        
    }
}
