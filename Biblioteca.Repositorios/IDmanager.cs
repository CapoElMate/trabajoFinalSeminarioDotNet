using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public static class IDmanager{
    
    //generar un archivo con id, solucion temporal.
    //la idea es tener un archivo con la ultima id de cada una de las entidades.

    private static readonly string nombreArchivo = "IDcounters.txt";
    public static int obtener(string entidad){
        
        int ultimoID=0;

        entidad = entidad.ToLower();

        // voy a guardar el proximo id a usar de cada entidad en el siguiente formato:
        // <entidad>:<IdProximo>
        // <entidad>:<IdProximo>
        // <entidad>:<IdProximo>
        // <entidad>:<IdProximo>
        //    ···
       
        try{
            //intento leer el archivo, si no existe tira error:
            using var sr = new StreamReader(nombreArchivo);  

            string strNro ="-1"; //le doy un valor por si no llega a encontrar el valor.

            //mientras no llegue al final del archivo:
            while(!sr.EndOfStream){
                
                string? linea = sr.ReadLine();//leo la prox. linea
                
                //Console.WriteLine(linea.Split(':')[0] +":"+ linea.Split(':')[1]); //DEBUG

                //si el primer elemento contiene el parametro entidad
                //(comparo si es null porque si la linea es null, paso a la siguiente)
                if(linea != null && linea.Split(':')[0].Contains(entidad)){ 
                    strNro = linea.Split(':')[1]; //guardo su valor en strNro.
                }

            }

            sr.Close();

            //parseo el numero, si el numero es -1, es porque no encontre la entidad.
            ultimoID = int.Parse(strNro);

            //si no lo encontre,
            if(ultimoID == -1){
                using var sw = new StreamWriter(nombreArchivo,true);
                sw.WriteLine($"{entidad}:0");
                ultimoID = 0;
                //Console.WriteLine("no se encontro la entidad.");
            }
        }
        
        //si intente leer el archivo pero no existe:
        catch(FileNotFoundException){
            using var sw = new StreamWriter(nombreArchivo,true); //creo un nuevo archivo
            sw.WriteLine($"{entidad}:0"); //inicializo el id de la entidad en 0
            sw.Close();
        }

        return ultimoID;
    }

    public static void incrementar(string entidad){

        entidad = entidad.ToLower();


        try{
            //intento leer el archivo, si no existe tira error:
            using var sr = new StreamReader(nombreArchivo);  

            string copiaArchivo="";

            bool seEncontro = false;

            //mientras no llegue al final del archivo:
            while(!sr.EndOfStream){
                
                string? linea = sr.ReadLine();//leo la prox. linea
                                
                //Console.WriteLine(linea.Split(':')[0] +":"+ linea.Split(':')[1]); //DEBUG

                //si el primer elemento contiene el parametro entidad
                //(comparo si es null porque si la linea es null, paso a la siguiente)
                if( (linea != null) && linea.Split(':')[0].Contains(entidad) ){
                    //concateno a copia archivo <entidad>:<id+1>
                    copiaArchivo += $"{entidad}:{int.Parse(linea.Split(':')[1]) + 1}\n"; // INCREMENTO en 1 el id
                    seEncontro = true;
                }else
                    copiaArchivo += linea+"\n"; //copio esa linea

            }

            sr.Dispose();

            //Si copia archivo no estuvo vacio, significa que tomo algunos valores
            if(copiaArchivo != ""){
                using var sw = new StreamWriter(nombreArchivo);
                sw.Write(copiaArchivo);
                sw.Close();
                
                if(!seEncontro)
                    throw new Exception("error, no se encontro esa entidad para incrementar");
                    
            }
            else{
                throw new Exception("error, archivo IDs vacio");
            }

        }
        
        //DEBUG:
        catch(FileNotFoundException)
        {
            throw new FileNotFoundException("error, no se encontro el archivo, probablemente esta modificando antes de buscar");
        }

    }

}
