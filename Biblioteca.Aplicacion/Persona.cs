namespace Biblioteca.Aplicacion;

public class Persona
{
        
    public Persona(int numeroCarnet, string nombre, string apellido, string direccion, string facultad, int telefono, string correoElectronico){
        this.id = -1;        
        this.numeroCarnet = numeroCarnet;
        this.nombre = nombre;
        this.apellido = apellido;
        this.direccion = direccion;
        this.facultad = facultad;
        this.telefono = telefono;
        this.correoElectronico = correoElectronico;
    }

    public int id {get; set;}
    public int numeroCarnet {get; protected set;}
    public string nombre {get;protected  set;}
    public string apellido {get; protected set;}
    public string direccion {get; protected set;}
    public string facultad {get; protected set;}
    public int telefono {get; protected set;}
    public string correoElectronico {get;protected set;}

    public override string ToString()
    {
        return $"{id},{numeroCarnet},{nombre},{apellido},{direccion},{facultad},{telefono},{correoElectronico}";
    }

}