using System.ComponentModel;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class RepositorioEstudianteTxt: IRepositorioEstudiante
{

    readonly protected string nombreArchivo = "estudiantes.txt";

    public void altaEstudiante(Estudiante estudiante)
    {
        //NOTA: no checkeo si se repite el id del estudiante, porque no deberia pasar.        
        //NOTA2: las personas comparten el contador de ID, asi no hay problemas en prestamo para distinguir entre personas estudiantes y profesores    .

        estudiante.id = IDmanager.Obtener("persona");  //modifica el id de estudiante para tener el de id manager
        IDmanager.Modificar("persona",estudiante.id+1);//hace que el id para esta categoria aumente en 1

        using var sw = new StreamWriter(nombreArchivo, true);//construyo un stream writer

        sw.WriteLine(estudiante.ToString());//guardo el estudiante en la prox. linea
        sw.Close();//cierro el stream writer
    }

    public void bajaEstudiante(int idEstudiante)
    {
        // este codigo va a consistir en cargar la lista en ListaEstudiantes,
        // e ir cargando todos los estudiantes excepto el que tiene la id igual al que le enviamos.
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaEstudiantes = listarEstudiantes();

        using var sw = new StreamWriter(nombreArchivo);

        bool seEncontro = false;


        foreach( Estudiante estudiante in listaEstudiantes ){

           //aca divide el substring y verifica que el id sea igual o no.            
            if( estudiante.id != idEstudiante) {
                sw.WriteLine(estudiante.ToString());
            }
            else
            {
                seEncontro = true;
            }

        }

        if(!seEncontro){
            throw new Exception("no se encontro para eliminar el estudiante con el id " + idEstudiante);
        }

    }


    public void modificarEstudiante(Estudiante estudianteIngresado)
    {
        // este codigo va a consistir en cargar la lista en memoria,
        // buscar el estudiante que tenga una id coincidente con el que le enviamos,        
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaEstudiantes = listarEstudiantes();

        bool encontrado = false;
        
        
        //aqui uso un while en vez de un for para salir cuando encuentro el estudiante
        int i = 0;
        while(!encontrado && i<listaEstudiantes.Count()){
            
            if(listaEstudiantes[i].id == estudianteIngresado.id){
                encontrado = true;
                listaEstudiantes[i] = estudianteIngresado;
            }

            i++;
        }

        //si no encontro el estudiante tiro un error.
        if(!encontrado)
            throw new Exception("no se encontro un estudiante con ese id.");

        //si no se encontro el estudiante:        
        using(var sw = new StreamWriter(nombreArchivo,false)){ // creo un nuevo streamwriter, append en false asi sobreescribe el anterior.
            
            foreach(Estudiante estudiante in listaEstudiantes){
                sw.WriteLine(estudiante.ToString());
            }
        }
        
        

    }



    public List<Estudiante> listarEstudiantes(){
        var listaEstudiantes = new List<Estudiante>();

        using (var sr = new StreamReader(nombreArchivo))
        {
            string? linea;

            while(!sr.EndOfStream)
            {
                linea = sr.ReadLine();
            
                if (linea != null){
                    listaEstudiantes.Add( stringAEstudiante(linea) );
                }
            }
        }

        return listaEstudiantes;
    }


    private Estudiante stringAEstudiante(string[] subLinea)
    {        
        if(subLinea.Length != 10){
            throw new Exception("string de datos invalido, cantidad de parametros del estudiante incorrectas");
        }
        
        //creo un nuevo estudiante basandome en el formato:
        //"{id},{numeroCarnet},{nombre},{apellido},{direccion},{facultad},{telefono},{correoElectronico}",{numeroAlumno},{carrera}";  
        return new Estudiante ( id: int.Parse(subLinea[0]) ,
                                numeroCarnet:       int.Parse(subLinea[1]) ,
                                nombre:             subLinea[2] , 
                                apellido:           subLinea[3] , 
                                direccion:          subLinea[4] , 
                                facultad:           subLinea[5] ,
                                telefono:           subLinea[6] ,
                                correoElectronico:  subLinea[7] ,
                                numeroAlumno:       int.Parse(subLinea[8]) ,
                                carrera:            subLinea[9]
                                );
    }
    
    //esta funcion cumple la funcion de la anterior pero tiene la funcionalidad de ya separar el string
    private Estudiante stringAEstudiante(string strInfoEstudiante)
    {        
        string[] subLinea = strInfoEstudiante.Split(',');
        
        return stringAEstudiante(subLinea);
    }

}
