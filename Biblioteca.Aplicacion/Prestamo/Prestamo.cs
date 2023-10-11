namespace Biblioteca.Aplicacion;
using System.Text.Json;

public class Prestamo{

/* requisitos:
Id, persona (identificado por el Id de la persona), libro (identificado por el Id del libro),
fecha de préstamo, fecha de devolución y estado del libro devuelto (en buen estado o dañado).
*/

//para cuando creo el prestamo:
public int id {get;}
public int persona {get;}
public int libro {get;}
public DateTime fechaDePrestamo {get;}

public bool estaDevuelto{get; protected set;}
//para cuando lo devuevo:
public DateTime fechaDeDevolucion {get; protected set;}
public bool estaEnBuenEstado{get; protected set;}


//constructor:
    public Prestamo(int persona, int libro, DateTime fechaDePrestamo){
        estaDevuelto = false;
        this.id = -1;
        this.persona = persona;
        this.libro = libro;
        this.fechaDePrestamo = fechaDePrestamo;
        //los inicio en null porque todavia no toman un valor.
            // fechaDeDevolucion = null;
            // estaEnBuenEstado = null;
    }

    public void devolver(DateTime fechaDeDevolucion, bool estaEnBuenEstado){
        estaDevuelto = true;
        this.fechaDeDevolucion = fechaDeDevolucion;
        this.estaEnBuenEstado = estaEnBuenEstado;
    }

    public override string ToString(){
        string str = "";

        str=$"{id},{persona},{libro},{fechaDePrestamo.ToString("yyyy-MM-dd")}"; //despues usar parse exact

        if(estaDevuelto)
            str += $",{fechaDeDevolucion.ToString("yyyy-MM-dd")},{estaEnBuenEstado}";

        return str;
    }   


}

