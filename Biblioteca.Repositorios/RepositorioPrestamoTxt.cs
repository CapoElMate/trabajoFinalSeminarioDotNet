using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Biblioteca.Aplicacion;

namespace Biblioteca.Repositorios;

public class RepositorioPrestamoTxt: IRepositorioPrestamo
{

    readonly protected string nombreArchivo = "prestamos.txt";

    //Este metodo cuenta la cantidad de ese libro que esten prestados ACTUALMENTE
    public int cantLibrosPrestados(int idLibro){

        var listaPrestamos = listarPrestamosActivos(); //genero la lista de prestamos activos
        int cant = 0; //la cantidad = 0
        
        //recorro toda la lista
        foreach(Prestamo p in listaPrestamos){
            
            //si el id de libro del prestamo actual coincide con el id del libro ingresado, 
            if(p.libro == idLibro){
                cant++; //incremento la cantidad en 1
            }

        }

        return cant;
    }

    public void realizarPrestamo(Prestamo prestamo)
    {
        //NOTA: no checkeo si se repite el id del prestamo, no deberia pasar.
        prestamo.id = IDmanager.Obtener("prestamo");  //modifica el id del prestamo para tener el de id manager
        IDmanager.Modificar("prestamo",prestamo.id+1);//hace que el id para esta categoria aumente en 1

        using var sw = new StreamWriter(nombreArchivo, true);//construyo un stream writer

        sw.WriteLine(prestamo.ToString());//guardo el prestamo en la prox. linea
        sw.Close();//cierro el stream writer
    }


/* //no se si lo uso ahora
    public Prestamo verPrestamo(int idLibro)
    {
        Libro? libro = null;
        bool encontrado = false;
        
        using (var sr = new StreamReader(nombreArchivo))
        {
       
            while(!encontrado && !sr.EndOfStream)
            {            
                string[]? subLinea = sr.ReadLine().Split(',');

                //si el id actual es igual al ingresado:
                if( subLinea!=null && subLinea[0].Equals( idLibro.ToString() )){
                    libro = stringALibro(subLinea);                
                    encontrado = true;//NOTA: use un boolean porque no se si esta bueno usar el break
                }
            }

            if (libro == null)
                throw new DataException("no se encontro el libro con el id: " + idLibro);//NOTA: use data exeption pero no sabia que exepcion usar


            sr.Close();            
        }

        return libro;
    }
*/


    //CHECKEAR este metodo, quizas tendria que hacer algo con el devolver, es raro que llame a devolver() fuera de la funcion
    public void devolverLibro(Prestamo prestamoIngresado)
    {
        // este codigo va a consistir en cargar la lista en memoria,
        // buscar el prestamo que tenga una id coincidente con el que le enviamos,        
        // remplazarlo en la lista,
        // y transformar la lista de nuevo en texto.

        var listaPrestamos = listarPrestamos();

        bool encontrado = false;
        
        
        //aqui uso un while en vez de un for para salir cuando encuentro el libro
        int i = 0;
        while(!encontrado && i<listaPrestamos.Count()){
            
            if(listaPrestamos[i].id == prestamoIngresado.id){
                encontrado = true;
                listaPrestamos[i] = prestamoIngresado;
            }

            i++;
        }

        //si no encontro el libro tiro un error.
        if(!encontrado)
            throw new Exception("no se encontro un prestamo con ese id.");

        
        using(var sw = new StreamWriter(nombreArchivo,false)){ // creo un nuevo streamwriter, append en false asi sobreescribe el anterior.
            
            foreach(Prestamo prestamo in listaPrestamos){
                sw.WriteLine(prestamo.ToString());
            }
        }
        
        

    }



    public List<Prestamo> listarPrestamos(){
        var listaPrestamos = new List<Prestamo>();

        using (var sr = new StreamReader(nombreArchivo))
        {
            string? linea;

            while(!sr.EndOfStream)
            {
                linea = sr.ReadLine();
            
                if (linea != null){
                    listaPrestamos.Add( stringAPrestamo(linea) );
                }
            }
        }

        return listaPrestamos;
    }

    public List<Prestamo> listarPrestamosActivos(){
        var listaPrestamos = new List<Prestamo>();
        Prestamo presTemp;

        // recorro todos los elementos del archivo de texto, y los voy guardando en la lista.
        // pero si el elemento prestamo ya esta devuelto, lo ignora.

        try{
            using (var sr = new StreamReader(nombreArchivo))
            {
                string? linea;

                while(!sr.EndOfStream)
                {
                    linea = sr.ReadLine();
                
                    if (linea != null){

                        presTemp = stringAPrestamo(linea); //el metodo string a prestamo crea un prestamo por medio de un string.
                        
                        if(!presTemp.estaDevuelto){
                            listaPrestamos.Add(presTemp);
                        }

                    }
                }
            }
        }
        //en caso que no encuentre el archivo
        catch(FileNotFoundException ex){
            //crea el archivo.
            using var sw = new StreamWriter(nombreArchivo);
            sw.Close();
        }
        

        return listaPrestamos;
    }

    private DateTime parsearFecha(string strFecha){
        //este metodo va a tomar un string con el formato (yyyy-MM-dd) y va a generar un DateTime
        
        string formato = "yyyy-MM-dd";        
        CultureInfo cultura = CultureInfo.InvariantCulture; //ignorar esto, es para que el formato quede bien
        
        return DateTime.ParseExact(strFecha, formato, cultura);
    }

    private Prestamo? stringAPrestamo(string[] subLinea)
    {        
        Prestamo prestamo; //declaro prestamo(objeto de retorno).

        //si la subcadena tiene 6 espacios es porque el libro ya fue devuelto.
        if(subLinea.Length == 6){
            
            //creo un nuevo prestamo basandome en el formato:
            //"{id},{persona},{libro},{fechaDePrestamo.ToString("yyyy-MM-dd"),{fechaDeDevolucion.ToString("yyyy-MM-dd")},{estaEnBuenEstado}}"
            prestamo = new Prestamo(    id:                 int.Parse(subLinea[0]),
                                        persona:            int.Parse(subLinea[1]),
                                        libro:              int.Parse(subLinea[2]),
                                        fechaDePrestamo:    parsearFecha(subLinea[3]));
            
            //y devuelvo el prestamo:
            prestamo.devolver(          fechaDeDevolucion:  parsearFecha(subLinea[4]),
                                        estaEnBuenEstado:   bool.Parse(subLinea[5]) );
        }
        else if(subLinea.Length == 4){
            //creo un nuevo prestamo basandome en el formato:
            //"{id},{persona},{libro},{fechaDePrestamo.ToString("yyyy-MM-dd"),{fechaDeDevolucion.ToString("yyyy-MM-dd")},{estaEnBuenEstado}}"
            prestamo = new Prestamo(    id:                 int.Parse(subLinea[0]),
                                        persona:            int.Parse(subLinea[1]),
                                        libro:              int.Parse(subLinea[2]),
                                        fechaDePrestamo:    parsearFecha(subLinea[3])  );
        }
        else 
            throw new Exception("cantidad de parametros para el prestamo erronea");
        

        return prestamo;
    }

    private Prestamo stringAPrestamo(string strInfoPrestamo)
    {        
        string[] subLinea = strInfoPrestamo.Split(',');
        
        return stringAPrestamo(subLinea);        
    }
}
