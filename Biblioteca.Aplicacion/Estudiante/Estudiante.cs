namespace Biblioteca.Aplicacion;

public class Estudiante : Persona
{
    public int numeroAlumno{get; protected set;}
    public string carrera{get; protected set;}

    public Estudiante( int numeroAlumno, string carrera,
    int id , int numeroCarnet, string nombre, string apellido, string direccion, string facultad, int telefono, string correoElectronico)     
    :base(numeroCarnet, nombre, apellido, direccion, facultad, telefono, correoElectronico){
        
        this.numeroAlumno=numeroAlumno;
        this.carrera = carrera;

    }

    public override string ToString()
    {
        return  $"{base.ToString()},{numeroAlumno},{carrera}";
    }

}