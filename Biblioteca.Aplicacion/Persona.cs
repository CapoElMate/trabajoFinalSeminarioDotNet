namespace Biblioteca.Aplicacion;

public class Persona
{
    public int? Id {get; set;}
    public int numeroCarnet {get; protected set;}
    public string nombre {get;protected  set;}
    public string apellido {get; protected set;}
    public string direccion {get; protected set;}
    public string facultad {get; protected set;}
    public string telefono {get; protected set;}
    public string correoElectronico {get;protected set;}
    

    //propiedad de navegacion:
    public List<Prestamo>? Prestamos {get; set;} 

    
    //constructor vacio. Esto soluciona un error con entity framework
    public Persona(){
        this.Id = null;        
        this.numeroCarnet = -1;
        this.nombre = "";
        this.apellido = "";
        this.direccion = "";
        this.facultad = "";
        this.telefono = "";
        this.correoElectronico = "";
        Prestamos = null;
    }

    //constructor sin id
    public Persona(int numeroCarnet, string nombre, string apellido, string direccion, string facultad, string telefono, string correoElectronico){
        this.Id = null;        
        this.numeroCarnet = numeroCarnet;
        this.nombre = nombre;
        this.apellido = apellido;
        this.direccion = direccion;
        this.facultad = facultad;
        this.telefono = telefono;
        this.correoElectronico = correoElectronico;
        Prestamos = null;

    }

    public Persona(int id ,int numeroCarnet, string nombre, string apellido, string direccion, string facultad, string telefono, string correoElectronico){
        this.Id = id;        
        this.numeroCarnet = numeroCarnet;
        this.nombre = nombre;
        this.apellido = apellido;
        this.direccion = direccion;
        this.facultad = facultad;
        this.telefono = telefono;
        this.correoElectronico = correoElectronico;
        Prestamos = null;

    }

    

    public override string ToString()
    {
        return $"{Id},{numeroCarnet},{nombre},{apellido},{direccion},{facultad},{telefono},{correoElectronico}";
    }

}