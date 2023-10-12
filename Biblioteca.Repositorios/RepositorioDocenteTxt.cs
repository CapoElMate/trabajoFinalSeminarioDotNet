using System.ComponentModel;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class RepositorioDocenteTxt: IRepositorioDocente
{

    readonly protected string nombreArchivo = "docentes.txt";

    public void altaDocente(Docente docente)
    {
        //NOTA: no checkeo si se repite el id del docente, porque no deberia pasar.        
        //NOTA2: las personas comparten el contador de ID, asi no hay problemas en prestamo para distinguir entre personas docentes y profesores    .

        docente.id = IDmanager.obtener("persona");  //modifica el id de docente para tener el de id manager
        IDmanager.incrementar("persona");//hace que el id para esta categoria aumente en 1

        using var sw = new StreamWriter(nombreArchivo, true);//construyo un stream writer

        sw.WriteLine(docente.ToString());//guardo el docente en la prox. linea
        sw.Close();//cierro el stream writer
    }

    public void bajaDocente(int idDocente)
    {
        // este codigo va a consistir en cargar la lista en ListaDocentes,
        // e ir cargando todos los docentes excepto el que tiene la id igual al que le enviamos.
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaDocentes = listarDocentes();

        using var sw = new StreamWriter(nombreArchivo);

        bool seEncontro = false;


        foreach( Docente docente in listaDocentes ){

           //aca divide el substring y verifica que el id sea igual o no.            
            if( docente.id != idDocente) {
                sw.WriteLine(docente.ToString());
            }
            else
            {
                seEncontro = true;
            }

        }

        if(!seEncontro){
            throw new Exception("no se encontro para eliminar el docente con el id " + idDocente);
        }

    }


    public void modificarDocente(Docente docenteIngresado)
    {
        // este codigo va a consistir en cargar la lista en memoria,
        // buscar el docente que tenga una id coincidente con el que le enviamos,        
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaDocentes = listarDocentes();

        bool encontrado = false;
        
        
        //aqui uso un while en vez de un for para salir cuando encuentro el docente
        int i = 0;
        while(!encontrado && i<listaDocentes.Count()){
            
            if(listaDocentes[i].id == docenteIngresado.id){
                encontrado = true;
                listaDocentes[i] = docenteIngresado;
            }

            i++;
        }

        //si no encontro el docente tiro un error.
        if(!encontrado)
            throw new Exception("no se encontro un estudiante con el id"+docenteIngresado.id+" para modificar.");

        //si no se encontro el docente:        
        using(var sw = new StreamWriter(nombreArchivo,false)){ // creo un nuevo streamwriter, append en false asi sobreescribe el anterior.
            
            foreach(Docente docente in listaDocentes){
                sw.WriteLine(docente.ToString());
            }
        }
        
        

    }



    public List<Docente> listarDocentes(){
        var listaDocentes = new List<Docente>();

        using (var sr = new StreamReader(nombreArchivo))
        {
            string? linea;

            while(!sr.EndOfStream)
            {
                linea = sr.ReadLine();
            
                if (linea != null){
                    listaDocentes.Add( stringADocente(linea) );
                }
            }
        }

        return listaDocentes;
    }


    private Docente stringADocente(string[] subLinea)
    {        
        if(subLinea.Length != 10){
            throw new Exception("string de datos invalido, cantidad de parametros del docente incorrectas");
        }
        
        //creo un nuevo docente basandome en el formato:
        //"{id},{numeroCarnet},{nombre},{apellido},{direccion},{facultad},{telefono},{correoElectronico}",{numeroMatricula},{añoInicioDocencia}"";  
        return new Docente (    id:                 int.Parse(subLinea[0]) ,
                                numeroCarnet:       int.Parse(subLinea[1]) ,
                                nombre:             subLinea[2] , 
                                apellido:           subLinea[3] , 
                                direccion:          subLinea[4] , 
                                facultad:           subLinea[5] ,
                                telefono:           subLinea[6] ,
                                correoElectronico:  subLinea[7] ,
                                nroMatricula:       int.Parse(subLinea[8]) ,
                                añoInicio:          int.Parse(subLinea[9])
                                );
    }
    
    //esta funcion cumple la funcion de la anterior pero tiene la funcionalidad de ya separar el string
    private Docente stringADocente(string strInfoDocente)
    {        
        string[] subLinea = strInfoDocente.Split(',');
        
        return stringADocente(subLinea);
    }

}
