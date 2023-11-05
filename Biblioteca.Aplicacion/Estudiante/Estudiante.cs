namespace Biblioteca.Aplicacion;

public class Estudiante : Persona
{
    public int numeroAlumno{get; set;}
    public string carrera{get; set;}


    //constructor vacio. Esto soluciona un error con entity framework
    public Estudiante():base() {
        this.numeroAlumno=-1;
        this.carrera = "";
    }

    public Estudiante(  int id , int numeroCarnet, string nombre, string apellido, 
                        string direccion, string facultad, string telefono, string correoElectronico,
                        int numeroAlumno, string carrera) //2 parametros unicos dee estudiante     
                        :base(id,numeroCarnet, nombre, apellido, direccion, facultad, telefono, correoElectronico) //accedo a la superclase y inicializo los metodos
    {        
        this.numeroAlumno=numeroAlumno;
        this.carrera = carrera;

    }

    public Estudiante( int numeroCarnet, string nombre, string apellido, 
                        string direccion, string facultad, string telefono, string correoElectronico,
                        int numeroAlumno, string carrera) //2 parametros unicos dee estudiante     
                        :base(numeroCarnet, nombre, apellido, direccion, facultad, telefono, correoElectronico) //accedo a la superclase y inicializo los metodos
    {
        
        this.numeroAlumno=numeroAlumno;
        this.carrera = carrera;

    }

    public override string ToString()
    {
        return  $"{base.ToString()},{numeroAlumno},{carrera}";
    }

}