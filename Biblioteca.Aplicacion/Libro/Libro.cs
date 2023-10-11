namespace Biblioteca.Aplicacion;


public class Libro{

    public int id {get; set;}
    public string? autor {get;}
    public string? titulo {get;}
    
    private int _añoPublicacion;
    public int añoPublicacion{
        
        get => _añoPublicacion;

        // si el año llega a ser mayor que el año actual, guarda -1, sino el valor.
        protected set => _añoPublicacion =    (value <= DateTime.Now.Year)  
                                                ? value 
                                                :throw new ArgumentException("el año de publi es mayor que el actual");
    }

    public string? genero {get;}

    public int numeroEjemplares {get; set;}
    
//CONSTRUCTOR:
    public Libro(string? autor, string? titulo, int añoPublicacion, string? genero, int numeroEjemplares){
        this.id = -1;
        this.autor = autor;
        this.titulo = titulo;
        this.añoPublicacion = añoPublicacion;
        this.genero = genero;
        this.numeroEjemplares = numeroEjemplares;
    }

    public Libro(int id,string? autor, string? titulo, int añoPublicacion, string? genero, int numeroEjemplares){
        this.id = id;
        this.autor = autor;
        this.titulo = titulo;
        this.añoPublicacion = añoPublicacion;
        this.genero = genero;
        this.numeroEjemplares = numeroEjemplares;
    }
    

    //to string:

    public override string ToString()
    {
        return $"{id},{autor},{titulo},{añoPublicacion},{genero},{numeroEjemplares}";
    }

}