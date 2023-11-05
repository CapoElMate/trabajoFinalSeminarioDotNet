namespace Biblioteca.Aplicacion;
using System.Text.Json;

public class Prestamo{

/* requisitos:
Id, persona (identificado por el Id de la persona), libro (identificado por el Id del libro),
fecha de préstamo, fecha de devolución y estado del libro devuelto (en buen estado o dañado).
*/

//para cuando creo el prestamo:
public int? id {get; set;}
public int PersonaId {get; set;}
public int LibroId {get;set;}
public DateTime fechaDePrestamo {get;set;}

public bool estaDevuelto{get; protected set;}
//para cuando lo devuevo:
public DateTime fechaDeDevolucion {get; set;}
public bool estaEnBuenEstado{get; set;}




//constructor:

    public Prestamo(){
        estaDevuelto = false;
        this.id = null;
        this.PersonaId = -1;
        this.LibroId = -1;
        this.fechaDePrestamo = DateTime.Now;
    }

    public Prestamo(int PersonaId, int libroId, DateTime fechaDePrestamo){
        estaDevuelto = false;
        
        this.id = null;
        this.PersonaId = PersonaId;
        this.LibroId = libroId;
        this.fechaDePrestamo = fechaDePrestamo;
    }

    public Prestamo(int id ,int PersonaId, int libroId, DateTime fechaDePrestamo){
        estaDevuelto = false;
        this.id = id;
        this.PersonaId = PersonaId;
        this.LibroId = libroId;
        this.fechaDePrestamo = fechaDePrestamo;
    }

    public void devolver(DateTime fechaDeDevolucion, bool estaEnBuenEstado){
        estaDevuelto = true;
        this.fechaDeDevolucion = fechaDeDevolucion;
        this.estaEnBuenEstado = estaEnBuenEstado;
    }

    public override string ToString(){
        string str = "";

        str=$"{id},{PersonaId},{LibroId},{fechaDePrestamo.ToString("yyyy-MM-dd")}"; //despues usar parse exact

        if(estaDevuelto)
            str += $",{fechaDeDevolucion.ToString("yyyy-MM-dd")},{estaEnBuenEstado}";

        return str;
    }   


}

