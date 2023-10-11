namespace Biblioteca.Aplicacion;

public class Estudiante : Persona
{
    public int numeroAlumno{get; protected set;}
    public string carrera{get; protected set;}

    public Estudiante(  int id , int numeroCarnet, string nombre, string apellido, 
                        string direccion, string facultad, int telefono, string correoElectronico,
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